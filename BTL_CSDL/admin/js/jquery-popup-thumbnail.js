// thumbnails
(function($, document, window, undefined) {
    var $doc = $(document);
    var thumbnail = {
        map: {
            none: '',
            iframe: '',
            ajax: '',
            vhtml5: ''
        },
        init: function(instance) {
            var self = this;
            var data = instance.group;
            var namespace = instance.namespace;
            var tpl = '<div class="' + namespace + '-thumb-wrap">' +
                '<a class="' + namespace + '-thumb-prev" alt="prev">prev</a>' +
                '<div class="' + namespace + '-thumb">' +
                '<ul class="' + namespace + '-thumb-items"></ul>' +
                '</div>' +
                '<a class="' + namespace + '-thumb-next" alt="next">next</a>' +
                '</div>';
            var $tpl = $(tpl);

            instance.$thumbnail = $tpl;
            this.$tpl = $tpl;
            this.$thumb = $tpl.find('.' + namespace + '-thumb');
            this.$items = $tpl.find('.' + namespace + '-thumb-items');
            this.$prev = $tpl.find('.' + namespace + '-thumb-prev');
            this.$next = $tpl.find('.' + namespace + '-thumb-next');

            this.total = data.length;
            this.index = 0;
            this.showCount = 5;
            this.width = 75;

            this.classes = {
                active: namespace + '-thumb_active',
                disabled: namespace + '-thumb_disabled'
            };

            //here add thumbnail
            $.each(data, function(i, v) {
                var url, img = new Image();
                if (v.options && v.options.thumb) {
                    url = v.options.thumb;
                } else if (self.map[v.type]) {
                    url = self.map[v.type];
                } else {
                    url = self.map.none;
                }

                img.src = url;
                $('<li></li>').append(img).appendTo(self.$items);
            });

            this.$items.css({
                width: this.total * this.width
            });
            this.$thumb.css({
                width: this.showCount * this.width
            });

            this.$prev.on('click', $.proxy(this.prev, this));
            this.$next.on('click', $.proxy(this.next, this));
            this.$thumb.delegate('li', 'click', function() {
                var index = self.$items.find('li').index(this);
                instance.goto(index);
                return false;
            });
            var count = instance.index + 1 - this.showCount;
            this.posIndex = count > 0 ? count : 0;
            $tpl.appendTo(instance.$container);
            this.active(instance.index);
        },
        close: function(instance) {
            this.unbindEvent();
            instance.$container.removeClass(instance.namespace + '_hasThumb');
        },
        active: function(index) {
            var className = this.classes.active;
            this.$items.find('.' + className).removeClass(className);
            this.$items.find('li').eq(index).addClass(className);

            this.index = index;
            this.resetPos(index);
        },
        resetPos: function(index) {
            var value = index * this.width;

            if (index >= this.posIndex && index < (this.showCount + this.posIndex)) {
                return false;
            } else if (index < this.posIndex) {
                this.posIndex = index;
                value = index * this.width;
            } else {
                // this.posIndex = this.showCount + 2 * this.posIndex - index + 1;
                this.posIndex = index - this.showCount + 1;
                value = this.posIndex * this.width;
            }

            this.$items.css({
                'margin-left': -value
            });
        },
        prev: function() {
            var current = Math.abs(parseInt(this.$items.css('margin-left'), 10));
            var step = this.showCount * this.width;

            if (current <= step) {
                this.$items.css({
                    'margin-left': 0
                });
            } else {
                this.$items.css({
                    'margin-left': -current + step
                });
            }
        },
        next: function() {
            var current = Math.abs(parseInt(this.$items.css('margin-left'), 10));
            var total = this.total * this.width;
            var step = this.showCount * this.width;

            if ((total - current - step) <= step) {
                this.$items.css({
                    'margin-left': -total + step
                });
            } else {
                this.$items.css({
                    'margin-left': -current - step
                });
            }
        },
        unbindEvent: function() {
            this.$prev.off('click');
            this.$next.off('click');
            this.$items.undelegate('click');
        },
        setShowCount: function(index) {
            this.showCount = index;
            if (this.total < this.showCount) {
                this.showCount = this.total;
            }
        }
    };

    $doc.on('popup::open', function(event, instance) {
        if (instance.isGroup && instance.options.thumbnail) {
            instance.$wrap.addClass(instance.namespace + '_hasThumb');
            thumbnail.init(instance);
        }
    });
    $doc.on('popup::change', function(event, instance) {
        if (instance.isGroup && instance.options.thumbnail) {
            thumbnail.active(instance.index);
        }
    });
    $doc.on('popup::close', function(event, instance) {
        if (instance.isGroup && instance.options.thumbnail) {
            thumbnail.close(instance);
        }
    });
})(jQuery, document, window);