"use strict";

var KTLocation = function () {

    var _handleCreateForm = function (e) {
        var validation;
        var form = KTUtil.getById('locationForm');

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            form,
            {
                fields: {
                    cName: {
                        validators: {
                            notEmpty: {
                                message: 'Ad alanı zorunludur.'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        $('#location_submit').on('click', function (e) {

            e.preventDefault();

            var _name = $("input[name=cName]").val();
            var _addLocationDto = {
                Name: _name
            }

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    $.ajax({
                        type: "POST",
                        url: "/Location/Add",
                        dataType: 'json',
                        data: _addLocationDto,
                        success: function (response) {
                            if (response.success) {
                                swal.fire({
                                    text: response.message,
                                    icon: "success",
                                    buttonsStyling: false,
                                    confirmButtonText: "Tamam",
                                    customClass: {
                                        confirmButton: "btn font-weight-bold btn-light-primary"
                                    }
                                }).then(function () {
                                    $("input[name=cName]").val('');
                                    location.href = "/Location/Index";
                                });
                            } else {
                                swal.fire({
                                    text: response.message,
                                    icon: "error",
                                    buttonsStyling: false,
                                    confirmButtonText: "Tamam",
                                    customClass: {
                                        confirmButton: "btn font-weight-bold btn-light-primary"
                                    }
                                }).then(function () {
                                    KTUtil.scrollTop();
                                });
                            }
                        },
                        error: function () {
                            swal.fire({
                                text: "Üzgünüz, eklerken bir sorunla karşılaştık.",
                                icon: "error",
                                buttonsStyling: false,
                                confirmButtonText: "Tamam",
                                customClass: {
                                    confirmButton: "btn font-weight-bold btn-light-primary"
                                }
                            }).then(function () {
                                KTUtil.scrollTop();
                            });
                        },
                    });

                } else {
                    swal.fire({
                        text: "Üzgünüz, eklerken bir sorunla karşılaştık.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Tamam",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });

    }
    
    var _handleDelete = function (e) {

        $('#location_delete').on('click', function (e) {

            e.preventDefault();

            var _id = $(this).data("id");

            swal.fire({
                title: "Lokasyonu Silmek İstediğinize Emin Misiniz?",
                type: 'warning',
                showDenyButton: true,
                confirmButtonText: 'Evet',
                denyButtonText: `İptal`,
                closeOnConfirm: false
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        url: "/Location/Delete",
                        dataType: 'json',
                        data: _id,
                        success: function (response) {
                            if (response.success) {
                                swal.fire({
                                    text: response.message,
                                    icon: "success",
                                    buttonsStyling: false,
                                    confirmButtonText: "Tamam",
                                    customClass: {
                                        confirmButton: "btn font-weight-bold btn-light-primary"
                                    }
                                }).then(function () {
                                    location.href = "/Location/Index";
                                });
                            } else {
                                swal.fire({
                                    text: response.message,
                                    icon: "error",
                                    buttonsStyling: false,
                                    confirmButtonText: "Tamam",
                                    customClass: {
                                        confirmButton: "btn font-weight-bold btn-light-primary"
                                    }
                                }).then(function () {
                                    KTUtil.scrollTop();
                                });
                            }
                        },
                        error: function () {
                            swal.fire({
                                text: "Üzgünüz, silme sırasında bir sorunla karşılaştık.",
                                icon: "error",
                                buttonsStyling: false,
                                confirmButtonText: "Tamam",
                                customClass: {
                                    confirmButton: "btn font-weight-bold btn-light-primary"
                                }
                            }).then(function () {
                                KTUtil.scrollTop();
                            });
                        },
                    });
                }
            });
        });
    }


    return {
        // public functions
        init: function () {
            _handleCreateForm();
            _handleDelete();
        }
    };

}();

jQuery(document).ready(function () {
    KTLocation.init();
});