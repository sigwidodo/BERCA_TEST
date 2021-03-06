var FormValidation = function () {
    var family = function () {
        var e = $("#form_family"),
            r = $(".alert-danger", e),
            i = $(".alert-success", e);
        e.validate({
            errorElement: "span",
            errorClass: "help-block help-block-error",
            focusInvalid: !1,
            ignore: "",
            rules: {
                name: { minlength: 2, required: !0 },
                birthdate: { required: !0, },
                relation: { required: !0, },
                famgender: { required: !0, },
                weddingdate: { required: !0, },
                effectivedate: { required: !0, },
            },
            invalidHandler: function (e, t) {
                i.hide(),
                r.show(),
                App.scrollTo(r, -200)
            },
            errorPlacement: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                i.removeClass("fa-check").addClass("fa-warning"),
                i.attr("data-original-title", e.text()).tooltip({ container: "body" })
            },
            highlight: function (e) {
                $(e).closest(".form-group").removeClass("has-success").addClass("has-error")
            },
            unhighlight: function (e) { },
            success: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                $(r).closest(".form-group").removeClass("has-error").addClass("has-success"),
                i.removeClass("fa-warning").addClass("fa-check")
            },
            submitHandler: function (e) {
                i.show(),
                r.hide(),
                e[0].submit()
            }
        }),
        $(".select2me", e).change(function () { e.validate().element($(this)) }), $(".date-picker").datepicker({ rtl: App.isRTL(), autoclose: !0 }), $(".date-picker .form-control").change(function () { e.validate().element($(this)) })
    },

    education = function () {
        var e = $("#form_education"),
            r = $(".alert-danger", e),
            i = $(".alert-success", e);
        e.validate({
            errorElement: "span",
            errorClass: "help-block help-block-error",
            focusInvalid: !1,
            ignore: "",
            rules: {
                institution: { minlength: 2, required: !0 },
                educationid: { required: !0, },
                location: { required: !0, },
                gradeyear: { required: !0, number: !0, minlength: 4 },
                ijazah: { required: !0, },
            },
            invalidHandler: function (e, t) {
                i.hide(),
                r.show(),
                App.scrollTo(r, -200)
            },
            errorPlacement: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                i.removeClass("fa-check").addClass("fa-warning"),
                i.attr("data-original-title", e.text()).tooltip({ container: "body" })
            },
            highlight: function (e) {
                $(e).closest(".form-group").removeClass("has-success").addClass("has-error")
            },
            unhighlight: function (e) { },
            success: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                $(r).closest(".form-group").removeClass("has-error").addClass("has-success"),
                i.removeClass("fa-warning").addClass("fa-check")
            },
            submitHandler: function (e) {
                i.show(),
                r.hide(),
                e[0].submit()
            }
        }),
        $(".select2me", e).change(function () { e.validate().element($(this)) }), $(".date-picker").datepicker({ rtl: App.isRTL(), autoclose: !0 }), $(".date-picker .form-control").change(function () { e.validate().element($(this)) })
    },

    jobs = function () {
        var e = $("#form_jobs"),
            r = $(".alert-danger", e),
            i = $(".alert-success", e);
        e.validate({
            errorElement: "span",
            errorClass: "help-block help-block-error",
            focusInvalid: !1,
            ignore: "",
            rules: {
                jobcompany: { minlength: 2, required: !0 },
                bussinesstype: { minlength: 2, required: !0 },
                jobstart: { required: !0, number: !0, minlength: 4 },
                jobsend: { required: !0, number: !0, minlength: 4 },
                jobtitleexp: { minlength: 2, required: !0 },
                jobdesc: { minlength: 2, required: !0 },
                lastsalary: { required: !0, number: !0, minlength: 4 },
                reasonout: { minlength: 2, required: !0 },
            },
            invalidHandler: function (e, t) {
                i.hide(),
                r.show(),
                App.scrollTo(r, -200)
            },
            errorPlacement: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                i.removeClass("fa-check").addClass("fa-warning"),
                i.attr("data-original-title", e.text()).tooltip({ container: "body" })
            },
            highlight: function (e) {
                $(e).closest(".form-group").removeClass("has-success").addClass("has-error")
            },
            unhighlight: function (e) { },
            success: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                $(r).closest(".form-group").removeClass("has-error").addClass("has-success"),
                i.removeClass("fa-warning").addClass("fa-check")
            },
            submitHandler: function (e) {
                i.show(),
                r.hide(),
                e[0].submit()
            }
        }),
        $(".select2me", e).change(function () { e.validate().element($(this)) }), $(".date-picker").datepicker({ rtl: App.isRTL(), autoclose: !0 }), $(".date-picker .form-control").change(function () { e.validate().element($(this)) })
    },

    employee = function () {
        var e = $("#form_employee_info"),
            r = $(".alert-danger", e),
            i = $(".alert-success", e);
        e.validate({
            errorElement: "span",
            errorClass: "help-block help-block-error",
            focusInvalid: !1,
            ignore: "",
            rules: {
                empcompname: { required: !0 },
                fullname: { minlength: 2, required: !0 },
                nik: { required: !0, number: !0, minlength: 10 },
                absentid: { required: !0, number: !0, minlength: 4 },
                jobtitle: { required: !0 },
                namen1: { required: !0 },
                idn1: { required: !0 },
                gender: { required: !0 },
                education: { required: !0, },
                empstatus: { required: !0 },
                joindate: { required: !0, minlength: 10 },
                start1: { required: !0, minlength: 10 },
                period1: { required: !0 },
                finish1: { required: !0 },
                prevcompany: { required: !0 },
                mutationdate: { required: !0, minlength: 10 },

            },
            invalidHandler: function (e, t) {
                i.hide(),
                r.show(),
                App.scrollTo(r, -200)
            },
            errorPlacement: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                i.removeClass("fa-check").addClass("fa-warning"),
                i.attr("data-original-title", e.text()).tooltip({ container: "body" })
            },
            highlight: function (e) {
                $(e).closest(".form-group").removeClass("has-success").addClass("has-error")
            },
            unhighlight: function (e) { },
            success: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                $(r).closest(".form-group").removeClass("has-error").addClass("has-success"),
                i.removeClass("fa-warning").addClass("fa-check")
            },
            submitHandler: function (e) {
                i.show(),
                r.hide(),
                e[0].submit()
            }
        }),
        $(".select2me", e).change(function () { e.validate().element($(this)) }), $(".date-picker").datepicker({ rtl: App.isRTL(), autoclose: !0 }), $(".date-picker .form-control").change(function () { e.validate().element($(this)) })
    },

    personal = function () {
        var e = $("#form_personal_info"),
            r = $(".alert-danger", e),
            i = $(".alert-success", e);
        e.validate({
            errorElement: "span",
            errorClass: "help-block help-block-error",
            focusInvalid: !1,
            ignore: "",
            rules: {
                birthplace: { minlength: 2, required: !0 },
                birthdate: { required: !0, minlength: 10 },
                maritalstatus: { required: !0 },
                religion: { required: !0 },
                cardno: { required: !0 },
                phone1: { required: !0, number: !0, minlength: 10 },
                famcardno: { required: !0 },
                emailoffice: { minlength: 2, required: !0 },
                emailprivate: { minlength: 2, required: !0, },
            },
            invalidHandler: function (e, t) {
                i.hide(),
                r.show(),
                App.scrollTo(r, -200)
            },
            errorPlacement: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                i.removeClass("fa-check").addClass("fa-warning"),
                i.attr("data-original-title", e.text()).tooltip({ container: "body" })
            },
            highlight: function (e) {
                $(e).closest(".form-group").removeClass("has-success").addClass("has-error")
            },
            unhighlight: function (e) { },
            success: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                $(r).closest(".form-group").removeClass("has-error").addClass("has-success"),
                i.removeClass("fa-warning").addClass("fa-check")
            },
            submitHandler: function (e) {
                i.show(),
                r.hide(),
                e[0].submit()
            }
        }),
        $(".select2me", e).change(function () { e.validate().element($(this)) }), $(".date-picker").datepicker({ rtl: App.isRTL(), autoclose: !0 }), $(".date-picker .form-control").change(function () { e.validate().element($(this)) })
    },

    organization = function () {
        var e = $("#form_organization"),
            r = $(".alert-danger", e),
            i = $(".alert-success", e);
        e.validate({
            errorElement: "span",
            errorClass: "help-block help-block-error",
            focusInvalid: !1,
            ignore: "",
            rules: {
                directorate: { required: !0 },
                subdirectorate: { required: !0 },
                division: { required: !0 },
                subdivision: { required: !0 },
                department: { required: !0 },
                subdepartment: { required: !0 },
                costcenter: { required: !0 },
                structurelevel: { required: !0 },
                functionallevel: { required: !0 },
                grade: { required: !0 },
                location: { required: !0 },
                payroll: { required: !0 },

            },
            invalidHandler: function (e, t) {
                i.hide(),
                r.show(),
                App.scrollTo(r, -200)
            },
            errorPlacement: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                i.removeClass("fa-check").addClass("fa-warning"),
                i.attr("data-original-title", e.text()).tooltip({ container: "body" })
            },
            highlight: function (e) {
                $(e).closest(".form-group").removeClass("has-success").addClass("has-error")
            },
            unhighlight: function (e) { },
            success: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                $(r).closest(".form-group").removeClass("has-error").addClass("has-success"),
                i.removeClass("fa-warning").addClass("fa-check")
            },
            submitHandler: function (e) {
                i.show(),
                r.hide(),
                e[0].submit()
            }
        }),
        $(".select2me", e).change(function () { e.validate().element($(this)) }), $(".date-picker").datepicker({ rtl: App.isRTL(), autoclose: !0 }), $(".date-picker .form-control").change(function () { e.validate().element($(this)) })
    },


     address = function () {
         var e = $("#form_address_ktp"),
             r = $(".alert-danger", e),
             i = $(".alert-success", e);
         e.validate({
             errorElement: "span",
             errorClass: "help-block help-block-error",
             focusInvalid: !1,
             ignore: "",
             rules: {
                 addressktp: { required: !0 },
                 provktp: { required: !0 },
                 cityktp: { required: !0 },
                 districtktp: { required: !0 },
                 villagektp: { required: !0 },
                 postcodektp: { required: !0 },
             },
             invalidHandler: function (e, t) {
                 i.hide(),
                 r.show(),
                 App.scrollTo(r, -200)
             },
             errorPlacement: function (e, r) {
                 var i = $(r).parent(".input-icon").children("i");
                 i.removeClass("fa-check").addClass("fa-warning"),
                 i.attr("data-original-title", e.text()).tooltip({ container: "body" })
             },
             highlight: function (e) {
                 $(e).closest(".form-group").removeClass("has-success").addClass("has-error")
             },
             unhighlight: function (e) { },
             success: function (e, r) {
                 var i = $(r).parent(".input-icon").children("i");
                 $(r).closest(".form-group").removeClass("has-error").addClass("has-success"),
                 i.removeClass("fa-warning").addClass("fa-check")
             },
             submitHandler: function (e) {
                 i.show(),
                 r.hide(),
                 e[0].submit()
             }
         }),
         $(".select2me", e).change(function () { e.validate().element($(this)) }), $(".date-picker").datepicker({ rtl: App.isRTL(), autoclose: !0 }), $(".date-picker .form-control").change(function () { e.validate().element($(this)) })
     },


      emergAddress = function () {
          var e = $("#form_address_emergency"),
              r = $(".alert-danger", e),
              i = $(".alert-success", e);
          e.validate({
              errorElement: "span",
              errorClass: "help-block help-block-error",
              focusInvalid: !1,
              ignore: "",
              rules: {
                  addressstatusemerg: { required: !0 },
                  nameemerg: { required: !0 },
                  phonenoemerg: { required: !0, number: !0, minlength: 10 },
              },
              invalidHandler: function (e, t) {
                  i.hide(),
                  r.show(),
                  App.scrollTo(r, -200)
              },
              errorPlacement: function (e, r) {
                  var i = $(r).parent(".input-icon").children("i");
                  i.removeClass("fa-check").addClass("fa-warning"),
                  i.attr("data-original-title", e.text()).tooltip({ container: "body" })
              },
              highlight: function (e) {
                  $(e).closest(".form-group").removeClass("has-success").addClass("has-error")
              },
              unhighlight: function (e) { },
              success: function (e, r) {
                  var i = $(r).parent(".input-icon").children("i");
                  $(r).closest(".form-group").removeClass("has-error").addClass("has-success"),
                  i.removeClass("fa-warning").addClass("fa-check")
              },
              submitHandler: function (e) {
                  i.show(),
                  r.hide(),
                  e[0].submit()
              }
          }),
          $(".select2me", e).change(function () { e.validate().element($(this)) }), $(".date-picker").datepicker({ rtl: App.isRTL(), autoclose: !0 }), $(".date-picker .form-control").change(function () { e.validate().element($(this)) })
      },

   
      t = function () {
          jQuery().wysihtml5 && $(".wysihtml5").size() > 0 && $(".wysihtml5").wysihtml5({
              stylesheets: ["../assets/global/plugins/bootstrap-wysihtml5/wysiwyg-color.css"]
          })
      }; return {
          init: function () {
              family(),
              education(),
              jobs(),
              employee(),
              personal(),
              organization(),
              address(),
              emergAddress()
          }
      }
}(); jQuery(document).ready(function () { FormValidation.init() });