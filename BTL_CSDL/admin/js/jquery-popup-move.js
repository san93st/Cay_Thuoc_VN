(function($, document, window, undefined) {
    function isTouchDevice() {
        var el = document.createElement('div');
        el.setAttribute('ongesturestart', 'return;');
        if (typeof el.ongesturestart === "function") {
            return true;
        } else {
            return false;
        }
    }
    var Touch = isTouchDevice();
    var downEvent, upEvent, moveEvent;
    if (Touch) {
        downEvent = 'touchstart.popup';
        upEvent = 'touchend.popup';
        moveEvent = 'touchmove.popup';
    } else {
        downEvent = 'mousedown.popup';
        upEvent = 'mouseup.popup';
        moveEvent = 'mousemove.popup';
    }
    var getEventObject = function(event) {
        var a = event.originalEvent;
        if (Touch) {
            a = a.touches[0];
        }
        return a;
    };
    $(document).on('popup::open', function(e, instance) {
        var data = {};
        var moveOrien;
        var mousedown = function(e) {
            var rightclick = (e.which) ? (e.which === 3) : (e.button === 2);
            if (rightclick) {
                return false;
            }

            data.startX = e.pageX;
            var position = 0;

            var mousemove = function(e) {
                var event = getEventObject(e);
                position = (event.pageX || data.startX) - data.startX;
                instance.$contentHolder.css({
                    left: position
                });
                prevent(event);
                return false;
            };
            var mouseup = function() {
                $(document).off(moveEvent);
                $(document).off(upEvent);

                instance.$contentHolder.css({
                    left: 0
                });
                if (position >= 10) {
                    instance.$contentHolder.css({
                        display: 'none'
                    });
                    moveOrien = 'next';
                    instance.next();
                } else if (position <= -10) {
                    instance.$contentHolder.css({
                        display: 'none'
                    });
                    moveOrien = 'left';
                    instance.prev();
                }
                prevent(e);
                return false;
            };

            $(document).on(moveEvent, mousemove).on(upEvent, mouseup);
            prevent(e);
            return false;
        };
        var prevent = function(e) {
            if (e.preventDefault) {
                e.preventDefault();
            } else {
                e.returnvalue = false;
            }
        };
        if (instance.isGroup) {
            instance.$contentHolder.css({
                position: 'relative'
            });
            instance.$contentHolder.on(downEvent, mousedown);
        }
    });
})(jQuery, document, window);