"use strict";

var KTActivity = function () {

    $('#kt_datetimepicker_1').datetimepicker({
        locale: 'tr'
    });
    $('#kt_datetimepicker_2').datetimepicker({
        locale: 'tr'
    });

    var _handleCreateForm = function (e) {
        var validation;
        var form = KTUtil.getById('activityForm');

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            form,
            {
                fields: {

                    aName: {
                        validators: {
                            notEmpty: {
                                message: 'Ad alanı zorunludur.'
                            }
                        }
                    },
                    aQuota: {
                        validators: {
                            notEmpty: {
                                message: 'Kontenjan alanı zorunludur.'
                            }
                        }
                    },
                    aAddress: {
                        validators: {
                            notEmpty: {
                                message: 'Adres alanı zorunludur.'
                            }
                        }
                    },
                    aHappenTime: {
                        validators: {
                            notEmpty: {
                                message: 'Etkinlik tarihi alanı zorunludur.'
                            }
                        }
                    },
                    aDeadline: {
                        validators: {
                            notEmpty: {
                                message: 'Son katılım tarihi alanı zorunludur.'
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

        // var isTicket = $("input[name=aIsTicket]:checked").val();
        // var priceCol = KTUtil.getById("priceCol");
        // if(!isTicket){
        //     priceCol.hidden;
        // }

        $('#activity_submit').on('click', function (e) {

            e.preventDefault();

            var _name = $("input[name=aName]").val();
            var _happenTime = $("input[name=aHappenTime]").val();
            var _deadline = $("input[name=aDeadline]").val();
            var _detail = $("textarea[name=aDetail]").val();
            var _categoryId = $("#aCategory").val();
            var _cityId = $("#aCity").val();
            var _address = $("input[name=aAddress]").val();
            var _quota = $("input[name=aQuota]").val();
            var _isTicket = $("input[name=aIsTicket]:checked").val();
            var _price = $("input[name=aPrice]").val();
            console.log(_name);
            console.log(_address);
            console.log(_cityId);
            var _activityViewModel = {
                activityCreateDto: {
                    Name: _name,
                    HappenTime: _happenTime,
                    Deadline: _deadline,
                    Detail: _detail,
                    CategoryId: _categoryId,
                    CityId: _cityId,
                    Address: _address,
                    Quota: _quota,
                    IsTicket: _isTicket,
                    Price: _price,
                }
            }

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    $.ajax({
                        type: "POST",
                        url: "/Activity/Create",
                        dataType: 'json',
                        data: _activityViewModel,
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
                                    location.href = "/Activity/WaitingApproveList";
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

    // var _handleUpdateForm = function (e) {
    //
    //     var validation;
    //     var form = KTUtil.getById('categoryUpdateForm');
    //
    //     // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
    //     validation = FormValidation.formValidation(
    //         form,
    //         {
    //             fields: {
    //                 cUpdateName: {
    //                     validators: {
    //                         notEmpty: {
    //                             message: 'Ad alanı zorunludur.'
    //                         }
    //                     }
    //                 },
    //             },
    //             plugins: {
    //                 trigger: new FormValidation.plugins.Trigger(),
    //                 bootstrap: new FormValidation.plugins.Bootstrap()
    //             }
    //         }
    //     );
    //
    //     $('#category_update_submit').on('click', function (e) {
    //
    //         e.preventDefault();
    //
    //         var _id = $(this).data("id");
    //         var _name = $("input[name=cUpdateName]").val();
    //         var _updateCategoryDto = {
    //             Id: _id,
    //             Name: _name
    //         }
    //
    //         validation.validate().then(function (status) {
    //             if (status == 'Valid') {
    //                 $.ajax({
    //                     type: "POST",
    //                     url: "/Category/Update",
    //                     dataType: 'json',
    //                     data: _updateCategoryDto,
    //                     success: function (response) {
    //                         if (response.success) {
    //                             swal.fire({
    //                                 text: response.message,
    //                                 icon: "success",
    //                                 buttonsStyling: false,
    //                                 confirmButtonText: "Tamam",
    //                                 customClass: {
    //                                     confirmButton: "btn font-weight-bold btn-light-primary"
    //                                 }
    //                             }).then(function () {
    //                                 $("input[name=cUpdateName]").val('');
    //                                 location.href = "/Category/Index";
    //                             });
    //                         } else {
    //                             swal.fire({
    //                                 text: response.message,
    //                                 icon: "error",
    //                                 buttonsStyling: false,
    //                                 confirmButtonText: "Tamam",
    //                                 customClass: {
    //                                     confirmButton: "btn font-weight-bold btn-light-primary"
    //                                 }
    //                             }).then(function () {
    //                                 KTUtil.scrollTop();
    //                             });
    //                         }
    //                     },
    //                     error: function () {
    //                         swal.fire({
    //                             text: "Üzgünüz, güncelleme sırasında bir sorunla karşılaştık.",
    //                             icon: "error",
    //                             buttonsStyling: false,
    //                             confirmButtonText: "Tamam",
    //                             customClass: {
    //                                 confirmButton: "btn font-weight-bold btn-light-primary"
    //                             }
    //                         }).then(function () {
    //                             KTUtil.scrollTop();
    //                         });
    //                     },
    //                 });
    //
    //             } else {
    //                 swal.fire({
    //                     text: "Üzgünüz, güncelleme sırasında bir sorunla karşılaştık.",
    //                     icon: "error",
    //                     buttonsStyling: false,
    //                     confirmButtonText: "Tamam",
    //                     customClass: {
    //                         confirmButton: "btn font-weight-bold btn-light-primary"
    //                     }
    //                 }).then(function () {
    //                     KTUtil.scrollTop();
    //                 });
    //             }
    //         });
    //     });
    // }
    //
    // var _handleDelete = function (e) {
    //
    //     $('#category_delete').on('click', function (e) {
    //
    //         e.preventDefault();
    //
    //         var _id = $(this).data("id");
    //
    //         swal.fire({
    //             title: "Kategoriyi Silmek İstediğinize Emin Misiniz?",
    //             type: 'warning',
    //             showDenyButton: true,
    //             confirmButtonText: 'Evet',
    //             denyButtonText: `İptal`,
    //             closeOnConfirm: false
    //         }).then((result) => {
    //             if (result.isConfirmed) {
    //                 $.ajax({
    //                     type: "POST",
    //                     url: "/Category/Delete",
    //                     dataType: 'json',
    //                     data: _id,
    //                     success: function (response) {
    //                         if (response.success) {
    //                             swal.fire({
    //                                 text: response.message,
    //                                 icon: "success",
    //                                 buttonsStyling: false,
    //                                 confirmButtonText: "Tamam",
    //                                 customClass: {
    //                                     confirmButton: "btn font-weight-bold btn-light-primary"
    //                                 }
    //                             }).then(function () {
    //                                 location.href = "/Category/Index";
    //                             });
    //                         } else {
    //                             swal.fire({
    //                                 text: response.message,
    //                                 icon: "error",
    //                                 buttonsStyling: false,
    //                                 confirmButtonText: "Tamam",
    //                                 customClass: {
    //                                     confirmButton: "btn font-weight-bold btn-light-primary"
    //                                 }
    //                             }).then(function () {
    //                                 KTUtil.scrollTop();
    //                             });
    //                         }
    //                     },
    //                     error: function () {
    //                         swal.fire({
    //                             text: "Üzgünüz, silme sırasında bir sorunla karşılaştık.",
    //                             icon: "error",
    //                             buttonsStyling: false,
    //                             confirmButtonText: "Tamam",
    //                             customClass: {
    //                                 confirmButton: "btn font-weight-bold btn-light-primary"
    //                             }
    //                         }).then(function () {
    //                             KTUtil.scrollTop();
    //                         });
    //                     },
    //                 });
    //             }
    //         });
    //     });
    // }


    return {
        // public functions
        init: function () {
            _handleCreateForm();
            // _handleUpdateForm();
            // _handleDelete();
        }
    };

}();

jQuery(document).ready(function () {
    KTActivity.init();
});