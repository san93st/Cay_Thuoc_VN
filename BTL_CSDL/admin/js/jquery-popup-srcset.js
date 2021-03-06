// srcset
(function(document, undefined) {
    'use strict';
    var $doc = $(document);
    var reInt = /^\d+$/;
    var srcset = {
        parse: function(str) {
            return deepUnique(str.split(',').map(function(el) {
                var ret = {};

                el.trim().split(/\s+/).forEach(function(el, i) {
                    if (i === 0) {
                        return ret.url = el;
                    }

                    var value = el.substring(0, el.length - 1);
                    var postfix = el[el.length - 1];
                    var intVal = parseInt(value, 10);
                    var floatVal = parseFloat(value);

                    if (postfix === 'w' && reInt.test(value)) {
                        ret.width = intVal;
                    } else if (postfix === 'h' && reInt.test(value)) {
                        ret.height = intVal;
                    } else if (postfix === 'x' && !isNaN(floatVal)) {
                        ret.density = floatVal;
                    } else {
                        throw new Error('Invalid srcset descriptor: ' + el + '.');
                    }
                });

                return ret;
            }));
        },
        stringify: function(arr) {
            return unique(arr.map(function(el) {
                if (!el.url) {
                    throw new Error('URL is required.');
                }

                var ret = [el.url];

                if (el.width) {
                    ret.push(el.width + 'w');
                }

                if (el.height) {
                    ret.push(el.height + 'h');
                }

                if (el.density) {
                    ret.push(el.density + 'x');
                }

                return ret.join(' ');
            })).join(', ');
        }
    };

    function deepUnique(arr) {
        return arr.sort().filter(function(el, i) {
            return JSON.stringify(el) !== JSON.stringify(arr[i - 1]);
        });
    }

    function unique(arr) {
        return arr.filter(function(el, i) {
            return arr.indexOf(el) === i;
        });
    }

    $doc.on('popup::init', function(event, instance) {

    });

    $(window).on('resize', function() {

    });


})(document);
