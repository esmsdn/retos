/// <reference path="import.ts" />
var index;
(function (index) {
    "use strict";

    var Sudoku = (function () {
        function Sudoku(classContainer) {
            this.board = [];
            this.links = {};
            // Get Dom elements
            this.container = $('.' + classContainer);
            this.links.isValid = $('.js-isvalid>a');

            // Bind events
            this.bindEvents();

            for (var i = 0; i < 9; i++) {
                var arr = [];
                for (var j = 0; j < 9; j++) {
                    arr[j] = 0;
                    this.board[i] = arr;
                }
            }
        }
        Sudoku.prototype.bindEvents = function () {
            var _this = this;
            this.container.find('.js-cell').on('blur', this.onBlurCell).on('keyup', function (e) {
                return _this.onChangeCell(e);
            });

            this.links.isValid.on('click', function (e) {
                return _this.onClickIsValid(e);
            });
        };

        Sudoku.prototype.onBlurCell = function () {
            // Add placeholder
            if ($(this).text() == '') {
                $(this).text('');
                $(this).removeClass('js-has_number');
            }
        };

        Sudoku.prototype.onChangeCell = function (e) {
            // Check cell value
            var $el = $(e.currentTarget);
            $el.removeClass('js-has_number');
            var val = parseInt($el.text(), 10);
            if (val < 1 || val > 9 || isNaN(val)) {
                $el.text('');
            } else {
                $el.addClass('js-has_number');
            }
            var keys = $el.data('sk').split(',');
            var val = parseInt($el.text(), 10);
            this.board[keys[0]][keys[1]] = ($el.text() === '') ? 0 : val;
            $el.blur();
        };

        Sudoku.prototype.sendRequest = function (url) {
            var _this = this;
            $.ajax({
                url: '/Home/' + url,
                type: 'POST',
                data: JSON.stringify({
                    Values: this.board
                }),
                contentType: 'application/json; charset=utf-8',
                success: function (e) {
                    return _this.onSuccess(e);
                },
                error: function (e) {
                    return console.log(e);
                }
            });
        };

        Sudoku.prototype.onClickIsValid = function (e) {
            this.sendRequest('IsValid');
        };

        Sudoku.prototype.onSuccess = function (response) {
            if (response) {
                this.container.removeClass('js-invalid');
                this.container.addClass('js-valid');
            } else {
                this.container.removeClass('js-valid');
                this.container.addClass('js-invalid');
            }
        };
        return Sudoku;
    })();

    window.onload = function () {
        var sudoku = new Sudoku('sudoku');
    };
})(index || (index = {}));
//# sourceMappingURL=Index.js.map
