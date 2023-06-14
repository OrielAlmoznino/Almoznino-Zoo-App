﻿$(document).ready(function () {
    let imagePathInput = $("#imagePath");
    let fileInput = $("#file");

    function toggleImageOptions() {
        let imageOptionCurrent = $("#imageOptionCurrent");
        let imageOptionUrl = $("#imageOptionUrl");
        let imageOptionUpload = $("#imageOptionUpload");

        let isCurrentImageSelected = imageOptionCurrent.prop("checked");
        let isUrlSelected = imageOptionUrl.prop("checked");
        let isUploadSelected = imageOptionUpload.prop("checked");

        imagePathInput.prop("disabled", !isUrlSelected);
        fileInput.prop("disabled", !isUploadSelected);

        // Show/hide error message
        let imageError = $("#imageError");
        imageError.text("");
        if (!isCurrentImageSelected && !isUrlSelected && !isUploadSelected) {
            imageError.text("Please select an image option.");
        }
    }

    toggleImageOptions();

    $("input[name='imageOption']").on("change", toggleImageOptions);
});
