
$(document).ready(function () {
        let imagePathInput = $("#imagePath");
    let fileInput = $("#file");

    function toggleImageOptions() {
        let imageOptionUrl = $("#imageOptionUrl");
    let imageOptionUpload = $("#imageOptionUpload");

    imagePathInput.prop("disabled", !imageOptionUrl.prop("checked"));
    fileInput.prop("disabled", !imageOptionUpload.prop("checked"));

    // Show/hide error message
    let imageError = $("#imageError");
    imageError.text("");
    if (!imageOptionUrl.prop("checked") && !imageOptionUpload.prop("checked")) {
        imageError.text("Please select an image option.");
            }
        }

    toggleImageOptions();

    $("input[name='imageOption']").on("change", toggleImageOptions);
    });
