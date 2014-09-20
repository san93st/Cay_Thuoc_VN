/*
 * popup
 * https://github.com/amazingSurge/popup
 *
 * Copyright (c) 2014 amazingSurge
 * Licensed under GPL licenses.
 */

(function($, document, window, undefined) {
    "use strict";
    
    var Popup = $.popup = function(element, options) {
        this.$element = $(element);
        this.$target = this.$element;

        this.isOpened = false;
        this.isGroup = false;
        this.group = [];
        this.index = 0;
        this.total = 0;
        this.type = '';
        this.url = '';

        if (!options) {
            options = {};
        }

        this.options = $.extend({}, Popup.defaults, options);
        this.namespace = this.options.namespace;

        this.classes = {
            skin: this.namespace + '_' + this.options.skin,
            cloak: this.namespace + '_cloak',
            group: this.namespace + '_group',
            loading: this.namespace + '_status_loading',
            complete: this.namespace + '_status_complete',
            fail: this.namespace + '_status_fail',
            noTrans: this.namespace + '_noTrans',
            transition: this.namespace + '_trans'
        };

        this._trigger('init');
        this.init();
    };
    Popup.prototype = {
        constructor: Popup,
        init: function() {
            var self = this;
            this.template = this._generateTemplate({
                namespace: this.namespace,
                closeText: this.options.closeText,
                loadingHtml: this.options.loadingHtml
            });
            this.$element.on('click', function() {
                var tag = $(this).data('popup-group');
                var group = tag ? self._filterGroup(tag, self.$element) : $(this);
                var index = $(group).index(this) || 0;

                self.group = self._getGroupConfig(group);
                self.$target = $(this);
                if (group.length > 1) {
                    self.isGroup = true;
                    self.total = group.length;
                }

                self.open();
                self.goto(index);

                $(window).on('resize.popup', $.proxy(self.resize, self));
                return false;
            });
            this._trigger('ready');
        },
        _trigger: function(eventType) {
            var method_arguments = Array.prototype.slice.call(arguments, 1),
                data = [this].concat(method_arguments);

            // event
            this.$element.trigger('popup::' + eventType, data);

            // callback
            eventType = eventType.replace(/\b\w+\b/g, function(word) {
                return word.substring(0, 1).toUpperCase() + word.substring(1);
            });
            var onFunction = 'on' + eventType;
            if (typeof this.options[onFunction] === 'function') {
                this.options[onFunction].apply(this, method_arguments);
            }
        },
        _generateTemplate: function(options) {
            var template = '<div class="popup-overlay"></div>' +
                '<div class="popup-wrap">' +
                '<div class="popup-container">' +
                '<div class="popup-content-wrap">' +
                '<div class="popup-content-holder">' +
                '<div class="popup-content"></div>' +
                '<div class="popup-infoBar">' +
                '<div class="popup-title"></div>' +
                '<span class="popup-counter"></span>' +
                '</div>' +
                '<button title="Close" type="button" class="popup-close">{{close}}</button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '<div class="popup-loading">{{loading}}</div>' +
                '</div>';
            return template.replace('popup', options.namespace)
                .replace('{{close}}', options.closeText)
                .replace('{{loading}}', options.loadingHtml);
        },
        _filterGroup: function(tag, collects) {
            return collects.filter(function() {
                var data = $(this).data('popup-group');
                if (tag) {
                    return data === tag;
                }
            });
        },
        _getGroupConfig: function(group) {
            var items = [],
                self = this;
            if ($.isArray(group)) {
                return group;
            }
            $.each(group, function(i, v) {
                var metas = {},
                    url = $(v).attr('href'),
                    obj = {
                        url: url,
                        target: v,
                        type: self.options.type || self._checkType(url)
                    };
                $.each($(v).data(), function(k, v) {
                    if (/^popup/i.test(k)) {
                        metas[k.toLowerCase().replace(/^popup/i, '')] = v;
                    }
                });
                obj.options = metas;
                if (metas.type) {
                    obj.type = metas.type;
                }
                items.push(obj);
            });

            return items;
        },
        _checkType: function(url) {
            var type = null;
            $.each(Popup.types, function(key, value) {
                if (typeof value.match === 'function') {
                    if (value.match(url)) {
                        type = value.match(url);
                    }
                }
            });
            return type;
        },
        open: function() {
            var $template = $(this.template),
                namespace = this.options.namespace;

            var selector = function(type) {
                return '.' + namespace + '-' + type;
            };

            this.$overlay = $template.eq(0);
            this.$wrap = $template.eq(1);

            this.$container = this.$wrap.find(selector('container'));
            this.$loading = this.$wrap.find(selector('loading'));
            this.$contentWrap = this.$container.find(selector('content-wrap'));
            this.$contentHolder = this.$contentWrap.find(selector('content-holder'));
            this.$content = this.$container.find(selector('content'));
            this.$close = this.$contentHolder.find(selector('close'));
            this.$title = this.$container.find(selector('title'));
            this.$counter = this.$container.find(selector('counter'));

            this.bindEvent();
            this.$contentHolder.addClass(this.classes.cloak);
            if (this.isGroup) {
                this.$container.addClass(this.classes.group);
                this.$next = $('<a title="prev" type="button" class="' + this.namespace + '-next"></a>');
                this.$prev = $('<a title="prev" type="button" class="' + this.namespace + '-prev"></a>');

                this.$next.on('click', $.proxy(this.next, this));
                this.$prev.on('click', $.proxy(this.prev, this));

                this.$next.add(this.$prev).appendTo(this.$container);
            }

            if (this.options.skin) {
                this.$overlay.addClass(this.classes.skin);
                this.$wrap.addClass(this.classes.skin);
            }
            if (this.options.imagePreload && this.isGroup) {
                this.imagePreload();
            }
            if (this.options.fullScreen) {
                this.fullScreen();
            }
            if (this.options.fullSize) {
                this.fullSize();
            }

            this._trigger('open');

            // window  effect
            this.$overlay.addClass(this.namespace + '_' + this.options.modalEffect + '_open');
            this.$contentWrap.addClass(this.options.modalEffect);
            this.$overlay.addClass(this.options.modalEffect + '-overlay');

            // for remove scroll
            $('body').addClass(this.namespace + '-body');
            this.$overlay.add(this.$wrap).appendTo('body');
        },
        afterLoad: function() {
            var self = this;
            setTimeout(function() {
                if (self.isOpened) {
                    self.$container.removeClass(self.classes.noTrans).removeClass(self.classes.transition);
                }

                // open transition
                self.$contentWrap.addClass('we-show');
                self.$overlay.addClass('we-show');
            }, 0);
            this._trigger('afterLoad');
            this.resize();
            if (this.options.preload) {
                this.preload();
            }
            this.isOpened = true;
        },
        goto: function(index) {
            var self = this,
                item = this.group[index];

            clearInterval(this.interval);
            clearTimeout(this.timeout);
            this.interval = undefined;
            this.timeout = undefined;

            this.settings = $.extend({}, this.options, item.options);
            this.index = index;
            this.type = this.settings.type || item.type;
            this.title = this.settings.title;
            this.url = item.url;

            // start change
            this._trigger('change');
            this.showLoading();

            Popup.types[item.type].load(this).then(function($data) {
                self.$container.addClass(self.namespace + '_' + item.type);
                self.$contentHolder.removeClass(self.classes.cloak);

                if (item.type !== 'iframe') {
                    self.hideLoading();
                    self.$wrap.addClass(self.classes.complete);
                }
                if (item.type !== 'inline') {
                    $data.addClass(self.namespace + '-content-inner');
                }

                self.$content.empty();
                if (self.isOpened) {
                    self.$container.addClass(self.classes.noTrans).addClass(self.classes.transition);
                }
                self.$contentHolder.css({
                    display: 'block'
                });
                self.$content.append($data);
                self.$title.text(self.title);
                if (self.isGroup) {
                    self.$counter.text((self.index + 1) + '/' + self.total);
                }
                self.afterLoad();
            }, function() {
                self.$content.empty().append(self.options.errorHtml);
                self.hideLoading();
                self.$wrap.addClass(self.classes.fail);
                self.$title.text(self.title);
                if (self.isGroup) {
                    self.$counter.text((self.index + 1) + '/' + self.total);
                }
                self.afterLoad();
            });
        },
        next: function() {
            var index = this.index;
            index++;
            if (index >= this.total) {
                index = 0;
            }

            this.direction = 'next';
            this.goto(index);
            return false;
        },
        prev: function() {
            var index = this.index;
            index--;
            if (index < 0) {
                index = this.total - 1;
            }
            this.direction = 'prev';
            this.goto(index);
            return false;
        },
        close: function() {
            var self = this;
            var delay = 0;

            this.$loading.css({
                display: 'none'
            });
            // open transition
            this.$contentWrap.removeClass('we-show');
            this.$overlay.removeClass('we-show');

            if (this.options.modalEffect !== '') {
                delay = 350;
            }
            setTimeout(function() {
                self.$overlay.remove();
                self.$wrap.remove();
                $('body').removeClass(self.namespace + '-body');

                $(window).off('resize.popup');
                self._trigger('close');
                self.isOpened = false;
            }, delay);
        },
        imagePreload: function($group) {
            $group.map(function(item) {
                if (item.type === 'image') {
                    var image = new Image();
                    image.src = item.url;
                }
            });
        },
        showLoading: function() {
            var self = this;
            self.$wrap
                .removeClass(self.classes.complete)
                .removeClass(self.classes.fail)
                .addClass(self.classes.loading);
        },
        hideLoading: function() {
            this.$wrap.removeClass(this.classes.loading);
        },
        fullScreen: function() {},
        fullSize: function() {},
        resize: function() {
            if (this.type === 'image') {
                Popup.types[this.type].resize(this);
            }
            this._trigger('resize');
        },
        bindEvent: function() {
            var self = this;
            this.$close.on('click', $.proxy(this.close, this));

            if (this.options.winBtn) {
                this.$wrap.on('click.popup', function(e) {
                    if ($(e.target).hasClass(self.namespace + '-container')) {
                        self.close();
                    }
                    return false;
                });
            }
        }
    };

    Popup.defaults = {
        namespace: 'popup',
        skin: 'default',
        winBtn: true,
        keyboard: true,
        preload: false,
        fullScreen: false,
        fullSize: false,
        imagePreload: false,
        closeText: 'x',
        loadingHtml: '<img src="Loading.gif" />',
        errorHtml: '<p style="width:500px;height:300px;text-align:center;background-color:#aaa;line-height:300px;">Error</p>',
        // thanks to http://tympanus.net/Development/ModalWindowEffects/
        modalEffect: 'we-fadeScale', // fadeScale slideIn fall flip rotate
        thumbnail: false,

        // type settings
        ajax: {
            // expect return html string
            render: function(data) {
                return $(data);
            },
            options: {
                dataType: 'html',
                headers: {
                    'popup': true
                }
            }
        },
        swf: {
            allowscriptaccess: 'always',
            allowfullscreen: 'true',
            wmode: 'transparent',
        },
        html5: {
            width: "100%",
            height: "100%",

            preload: "load",
            controls: "controls",
            poster: '',

            type: {
                mp4: "video/mp4",
                webm: "video/webm",
                ogg: "video/ogg",
            },

            // example
            // source: [
            //     {
            //         src: 'video/movie.mp4',
            //         type: 'mp4', // mpc,webm,ogv
            //     },
            //     {
            //         src: 'video/movie.webm',
            //         type: 'webm',
            //     },
            //     {
            //         src: 'video/movie.ogg',
            //         type: 'ogg',
            //     }
            // ]
            source: null
        }
    };

    Popup.types = {
        image: {
            match: function(url) {
                if (url.match(/\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$/i)) {
                    return 'image';
                } else {
                    return false;
                }
            },
            getSize: function(img, instance) {
                var timer,
                    dtd = $.Deferred(),
                    counter = 0,
                    interval = function(delay) {
                        if (timer) {
                            clearInterval(timer);
                        }
                        timer = setInterval(function() {
                            if (img.naturalWidth > 0) {
                                dtd.resolve($(img));
                                clearInterval(timer);
                                return;
                            }

                            // for IE 8/7 and below
                            // thanks to http://www.jacklmoore.com/notes/naturalwidth-and-naturalheight-in-ie/
                            if (img.width) {
                                dtd.resolve($(img));
                                clearInterval(timer);
                                return;
                            }

                            if (counter > 200) {
                                clearInterval(timer);
                                dtd.reject();
                            }

                            counter++;
                            if (counter === 3) {
                                interval(10);
                            } else if (counter === 40) {
                                interval(50);
                            } else if (counter === 100) {
                                interval(500);
                            }
                        }, delay);
                        instance.interval = timer;
                    };
                interval(1);
                img.onerror = function() {
                    this.onload = this.onerror = null;
                    clearInterval(instance.interval);
                    dtd.reject();
                };
                return dtd.promise();
            },
            // Progressive Image Rendering
            // and we need konw image width before add it to page
            // thanks to http://www.codinghorror.com/blog/2005/12/progressive-image-rendering.html
            load: function(instance) {
                var img = new Image();

                img.src = instance.url;
                return this.getSize(img, instance);
            },
            resize: function(instance) {
                var height = instance.$container.height();

                // todo avoid visit Dom
                instance.$content.find('img').css({
                    // minus five to be sure image height less than container
                    'max-height': parseInt(height, 10) - 5
                });
            }
        },
        iframe: {
            match: function(url) {
                if (url.match(/\.(ppt|PPT|tif|TIF|pdf|PDF)$/i)) {
                    return 'iframe';
                } else {
                    return false;
                }
            },
            load: function(instance) {
                var dtd = $.Deferred();
                // thanks to http://www.planabc.net/2009/09/22/iframe_onload/
                var iframe = document.createElement("iframe");
                iframe.src = instance.url;
                if (iframe.attachEvent) {
                    iframe.attachEvent("onload", function() {
                        instance.hideLoading();
                        instance.$wrap.addClass(instance.classes.complete);
                    });
                } else {
                    iframe.onload = function() {
                        instance.hideLoading();
                        instance.$wrap.addClass(instance.classes.complete);
                    };
                }
                dtd.resolve($(iframe));
                return dtd.promise();
            }
        },
        inline: {
            match: function(url) {
                if (url.charAt(0) === "#") {
                    return 'inline';
                } else {
                    return false;
                }
            },
            load: function(instance) {
                var dtd = $.Deferred();
                var content = $(instance.url).html();
                if (content) {
                    dtd.resolve(content);
                } else {
                    dtd.reject();
                }
                return dtd.promise();
            }
        },
        ajax: {
            load: function(instance) {
                var ajax = instance.settings.ajax;
                var dtd = $.Deferred();

                $.ajax($.extend({}, ajax.options, {
                    url: instance.url,
                    error: function() {
                        dtd.reject();
                    },
                    success: function(data) {
                        var $ajax;
                        if ($.type(ajax.render) === 'function') {
                            $ajax = ajax.render(data);
                        } else {
                            $ajax = $(data);
                        }
                        dtd.resolve($ajax);
                    }
                }));
                return dtd.promise();
            }
        },
        swf: {
            match: function(url) {
                if (url.match(/\.(swf)((\?|#).*)?$/i)) {
                    return 'swf';
                } else {
                    return false;
                }
            },
            load: function(instance) {
                var content = '',
                    embed = '',
                    swf = instance.settings.swf;
                var dtd = $.Deferred();

                content += '<object class="' + instance.namespace + '-swf" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="100%" height="100%">';
                content += '<param name="movie" value="' + instance.url + '"></param>';

                // this is swf settings
                $.each(swf, function(name, val) {
                    content += '<param name="' + name + '" value="' + val + '"></param>';
                    embed += ' ' + name + '="' + val + '"';
                });

                content += '<embed src="' + instance.url + '" type="application/x-shockwave-flash"  width="100%" height="100%"' + embed + '></embed>';
                content += '</object>';

                dtd.resolve($(content));
                return dtd.promise();
            }
        },
        html5: {
            match: function(url) {
                if (url.match(/\.(mp4|webm|ogg)$/i)) {
                    return 'html5';
                } else {
                    return false;
                }
            },
            load: function(instance) {
                var video = '',
                    sourceLists, type,
                    html5 = instance.settings.html5;
                var dtd = $.Deferred();

                video += '<video class="' + instance.namespace + '-html5"';
                video += ' width:' + html5.width;
                video += ' height:' + html5.height;
                video += ' ' + html5.preload;
                video += ' ' + html5.controls;
                video += ' poster:' + html5.poster;
                video += ' >';

                sourceLists = instance.url.split(',');

                //get videos address from url
                if (sourceLists.length !== 0) {
                    for (var i = 0, len = sourceLists.length; i < len; i++) {
                        type = $.trim(sourceLists[i].split('.')[1]);
                        video += '<source src="' + sourceLists[i] + '" type="' + html5.type[type] + '"></source>';
                    }
                }

                //get videos address from options
                if (html5.source && html5.source.length !== 0) {
                    $.each(html5.source, function(i, arr) {
                        video += '<source src="' + arr.src + '" type="' + html5.type[arr.type] + '"></source>';
                    });
                }

                video += '</video>';

                dtd.resolve($(video));
                return dtd.promise();
            }
        }
    };

    $.fn.popup = function(options) {
        if (typeof options === 'string') {
            var method = options;
            var method_arguments = Array.prototype.slice.call(arguments, 1);
            return this.each(function() {
                var api = $.data(this, 'popup');
                if (typeof api[method] === 'function') {
                    api[method].apply(api, method_arguments);
                }
            });
        } else {
            if (!$(this).data('popup')) {
                $(this).data('popup', new Popup(this, options));
            }
        }
    };
})(jQuery, document, window);