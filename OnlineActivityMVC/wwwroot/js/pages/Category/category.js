"use strict";

var KTCategory = function () {

    var _handleCreateForm = function (e) {
        var validation;
        var form = KTUtil.getById('categoryForm');

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

        $('#category_submit').on('click', function (e) {

            e.preventDefault();

            var _name = $("input[name=cName]").val();
            var _addCategoryDto = {
                Name: _name
            }

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    $.ajax({
                        type: "POST",
                        url: "/Category/Add",
                        dataType: 'json',
                        data: _addCategoryDto,
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
                                    location.href = "/Category/Index";
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
                                text: "Üzgünüz, kayıt olurken bir sorunla karşılaştık.",
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
                        text: "Üzgünüz, kayıt olurken bir sorunla karşılaştık.",
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

    var _handleUpdateForm = function (e) {

        var validation;
        var form = KTUtil.getById('categoryUpdateForm');

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            form,
            {
                fields: {
                    cUpdateName: {
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

        $('#category_update_submit').on('click', function (e) {

            e.preventDefault();

            var _id = $(this).data("id");
            var _name = $("input[name=cUpdateName]").val();
            var _updateCategoryDto = {
                Id: _id,
                Name: _name
            }

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    $.ajax({
                        type: "POST",
                        url: "/Category/Update",
                        dataType: 'json',
                        data: _updateCategoryDto,
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
                                    $("input[name=cUpdateName]").val('');
                                    location.href = "/Category/Index";
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
                                text: "Üzgünüz, güncelleme sırasında bir sorunla karşılaştık.",
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
                        text: "Üzgünüz, güncelleme sırasında bir sorunla karşılaştık.",
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

        $('#category_delete').on('click', function (e) {

            e.preventDefault();

            var _id = $(this).data("id");

            swal.fire({
                title: "Kategoriyi Silmek İstediğinize Emin Misiniz?",
                type: 'warning',
                showDenyButton: true,
                confirmButtonText: 'Evet',
                denyButtonText: `İptal`,
                closeOnConfirm: false
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        url: "/Category/Delete",
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
                                    location.href = "/Category/Index";
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
            _handleUpdateForm();
            _handleDelete();
        }
    };

}();

jQuery(document).ready(function () {
    KTCategory.init();
});