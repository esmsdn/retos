/// <reference path="import.ts" />

module index {
    "use strict";

    class Sudoku {

        private container: any;
        private board: number[][] = [];
        private links: any = {};

        constructor(classContainer: string) {
            // Get Dom elements
            this.container = $('.' + classContainer);
            this.links.isValid = $('.js-isvalid>a');

            // Bind events
            this.bindEvents();

            // initialize board
            for (var i: number = 0; i < 9; i++) {
                var arr = [];
                for (var j: number = 0; j < 9; j++) {
                    arr[j] = 0;
                    this.board[i] = arr;
                }
            }
        }

        private bindEvents() {
            this.container.find('.js-cell')
                .on('blur', this.onBlurCell)
                .on('keyup', e => this.onChangeCell(e));

            this.links.isValid.on('click', e => this.onClickIsValid(e));
        }

        private onBlurCell() {
            // Add placeholder
            if ($(this).text() == '') {
                $(this).text('')
                $(this).removeClass('js-has_number');
            }
        }

        private onChangeCell(e) {
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
        }

        private sendRequest(url: string) {
            $.ajax({
                url: '/Home/' + url,
                type: 'POST',
                data: JSON.stringify({
                    Values: this.board,
                }),
                contentType: 'application/json; charset=utf-8',
                success: e => this.onSuccess(e),
                error: e => console.log(e)
            });
        }

        private onClickIsValid(e: Event) {
            this.sendRequest('IsValid');
        }

        private onSuccess(response) {
            if (response) {
                this.container.removeClass('js-invalid');
                this.container.addClass('js-valid');
            } else {
                this.container.removeClass('js-valid');
                this.container.addClass('js-invalid');
            }
        }
    }
    
    window.onload = () => {
        var sudoku = new Sudoku('sudoku');
    }

}
