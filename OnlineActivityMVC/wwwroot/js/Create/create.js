"use strict";

var KTCreate = function () {

    var _handleCreateForm = function (e) {
        var validation;
        var form = KTUtil.getById('announcementForm');

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            form,
            {
                fields: {
                    CTitle: {
                        validators: {
                            notEmpty: {
                                message: 'Başlık alanı zorunludur.'
                            }
                        }
                    },
                    CText: {
                        validators: {
                            notEmpty: {
                                message: 'İçerik alanı zorunludur.'
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

        $('#announcement_submit').on('click', function (e) {

            e.preventDefault();

            var _cTitle = $("input[name=CTitle]").val();
            var _cText = $("textarea[name=CText]").val();
            var _cCity = $("select[name=CCity]").val();
            var _announcementCreateModel = {

                createDto: {
                    Text: _cText,
                    Title: _cTitle,
                    CityId: _cCity
                }
            }

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    $.ajax({
                        type: "POST",
                        url: "/Announcement/Create",
                        dataType: 'json',
                        data: _announcementCreateModel,
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
                                    $("input[name=CTitle]").val('');
                                    $("input[name=CText]").val('');
                                    location.href = "/Announcement/Index";
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

        $('#update_announcement_submit').on('click', function (e) {

            e.preventDefault();

            var _cTitle = $("input[name=CTitle]").val();
            var _cText = $("textarea[name=CText]").val();
            var _cCity = $("select[name=CCity]").val();
            var _announcementUpdateModel = {
                updateDto: {
                    Text: _cText,
                    Title: _cTitle,
                    CityId: _cCity
                }
            }

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    $.ajax({
                        type: "POST",
                        url: "/Announcement/Update",
                        dataType: 'json',
                        data: _announcementUpdateModel,
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
                                    $("input[name=CTitle]").val('');
                                    $("input[name=CText]").val('');
                                    location.href = "/Announcement/MyAnnouncements";
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
        var form = KTUtil.getById('announcementUpdateForm');

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            form,
            {
                fields: {
                    CTitle: {
                        validators: {
                            notEmpty: {
                                message: 'Başlık alanı zorunludur.'
                            }
                        }
                    },
                    CText: {
                        validators: {
                            notEmpty: {
                                message: 'İçerik alanı zorunludur.'
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



        $('#update_announcement_submit').on('click', function (e) {

            e.preventDefault();

            var _cTitle = $("input[name=CTitle]").val();
            var _cText = $("textarea[name=CText]").val();
            var _cCity = $("select[name=CCity]").val();
            var _announcementUpdateModel = {
                updateDto: {
                    Text: _cText,
                    Title: _cTitle,
                    CityId: _cCity
                }
            }

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    $.ajax({
                        type: "POST",
                        url: "/Announcement/Update",
                        dataType: 'json',
                        data: _announcementUpdateModel,
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
                                    $("input[name=CTitle]").val('');
                                    $("input[name=CText]").val('');
                                    location.href = "/Announcement/MyAnnouncements";
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


    var _handlerTab = function () {
        $('.nav-tabs a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        });
    }

    return {
        // public functions
        init: function () {
            _handlerTab();
            _handleCreateForm();
            _handleUpdateForm();
        }
    };

}();

jQuery(document).ready(function () {
    KTCreate.init();
});