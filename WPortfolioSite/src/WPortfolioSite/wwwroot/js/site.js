$(document).ready(function () {
    $('[data-toggle="popover"]').popover({ html: true });

    $('body').on('click', function (e) {
        //did not click a popover toggle or popover
        if ($(e.target).data('toggle') !== 'popover' &&
            $(e.target).parents('.popover.in').length === 0) {
            $('[data-toggle="popover"]').popover('hide');
        } else {
            // Stop scrolling to top of page on click
            e.preventDefault();
        }
    });
});

$('[data-toggle="collapse"]').on('click', function (e) {
    var span = $(this).find(' > span');
    if ($(this).next().hasClass('collapse in')) {
        span.find(' > i').addClass('fa-plus-circle').removeClass('fa-minus-circle');
    } else {
        span.find(' > i').addClass('fa-minus-circle').removeClass('fa-plus-circle');
    }
});

/**
 * @function populateModal
 * @params filenameIn - Name of file being rendered in modal
 *
 * @desc This function renders a source file inside of a bootstrap modal
 */
function populateModal (filenameIn)
{
    var filenameHeading = document.getElementById("fnameModal");
    filenameHeading.innerHTML = filenameIn;
    var safefn = filenameIn.replace(".", "_");
    $.ajax({
        url: "api/Files/" + safefn,
        dataType: "text",
        success: function (result) {
            $("#srcprecode").text(result);
            $("#srcprecode").removeClass();
            $('pre code').each(function (i, block) {
                hljs.configure({
                    languages: [
                        "armasm", "avrasm", "Bash", "C++", "C#", "Java", "JavaScript", "PHP", "SQL", "x86asm"
                    ]
                })
                hljs.highlightBlock(block);
            });
        }
    });
    
}

/**
 * @function addFile
 *
 * @desc This function adds additional input fields for each file added
 */
function addFile()
{
    $('#fnForm').append("<input name='filenamesArr[]' class='form-control' />")
}