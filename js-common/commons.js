$(document).ready(function () {
    //$(document).keydown(function (event) {
    //    if (event.ctrlKey == true && (event.which == '61' || event.which == '107' || event.which == '173' || event.which == '109' || event.which == '187' || event.which == '189')) {
    //        event.preventDefault();
    //    }
    //    // 107 Num Key  +
    //    // 109 Num Key  -
    //    // 173 Min Key  hyphen/underscor Hey
    //    // 61 Plus key  +/= key
    //});
    var keyCodes = [61, 107, 109, 187, 189];

    $(document).keydown(function (event) {
        if (event.ctrlKey == true && (keyCodes.indexOf(event.which) != -1)) {
            alert('disabling zooming');
            event.preventDefault();
        }
    });
    //$(window).bind('mousewheel DOMMouseScroll', function (event) {
    //    if (event.ctrlKey == true) {
    //        event.preventDefault();
    //    }
    //});


    //for page login;
    $("input[name=username-login]").click(function () {
        $(this).val("");
    });
    $("input[name=password-login]").click(function () {
        $(this).val("");
    });
    $("input[name=username-login]").blur(function () {
        $(this).val("نام کاربری");
    });
    $("input[name=password-login]").blur(function () {
        $(this).val("پسورد");
    });
    $("input[name=username-login]").find(function () {
        $(this).val("نام کاربری");
    });
    $("input[name=password-login]").find(function () {
        $(this).val("پسورد");
    });

    // for page main meno
    $('div.main-rightMenu ul.justify li a').click(function () {
        var item = $(this);
        var count = $('div.main-rightMenu ul.justify li a').find("span.arrow.open").length;

        var item_span = $(this).find("span.arrow");
        $(item_span).toggleClass("open");
        var has = $(item_span).hasClass("open");
        var duration = 'slow';
        var next_element = $(item).next();
        if (has == true) {
            $(next_element).removeClass('hidden');
            $(next_element).slideDown(duration);
            //$(next_element).animate( 5000, 'easeOutBounce');
            if ($('div.main-rightMenu ul.justify li a').find("span.arrow.open").length == 0) {
                var item_span = $('div.main-rightMenu ul.justify li a').find("span.arrow.open");
                $(item_span).removeClass("open");
                var father = $(item_span).parent();
                var next_element = $(father).next();
                $(next_element).addClass('hidden');
                $(next_element).slideUp(duration);
            }
        }
        else {
            $(next_element).addClass('hidden');
            $(next_element).slideUp(duration);
            //$(next_element).animate('slow', 'easeOutBounce');
            if ($('div.main-rightMenu ul.justify li a').find("span.arrow.open").length == 0) {
                var item_span = $('div.main-rightMenu ul.justify li a').find("span.arrow.open");
                $(item_span).addClass("open");
                var father = $(item_span).parent();
                var next_element = $(father).next();
                $(next_element).removeClass('hidden');
                $(next_element).slideDown(duration);
            }
        }


    });
    $("div.main-rightMenu a").click(function () {
        $(this).css("text-decoration", "none");
    })
   

    $("li#exite-program").click(function () {
        $("div.modal.fade").css("display", "block", "opacity", "1");
        $("div.modal").slideDown(2000);



    });


    //ba zadan docmeye search dar form doctors panel search show
    $(".btnShow_search").click(function () {
        var item = $("div.panel_search").slideToggle(2000).toggleClass("hidden");
        if (!item.hasClass('hidden'))
            $("div.main-rightMenu").css({ "height": "900px" });
        else
            $("div.main-rightMenu").css({ "height": "700px" });
   


    });
 


    //-----------------------------------------------------------------
    //validation


    //validation form doctore
    $(".btnDoctor_sabt").click(function () {

        $(".form-doctores").validate({
            errorClass: 'bashe',
            rules: {
                inpName: {
                    required: true,
                                    },
                inpFamily: {
                    required: true,
                },
                inpExpert: {
                    required: true,
                }
                ,
                inpMobile: {
                    required: true,
                    minlength: 11
                    ,
                    number: true
                }
                ,
                inpDegree: {
                    required: true,
                },
                DrpPart: {
                    required: true,
                }
            },

            messages: {
                inpName: { required: "فیلد نام الزامی هست." },
                inpFamily: { required: "فیلد فامیلی الزامی هست." },
               
                inpMobile: { required: "فیلد موبایل الزامی هست.", minlength: "لطفا موبایل را صحیح وارد کنید." },
                inpExpert: { required: "فیلد تخصص الزامی هست" },
                inpDegree: { required: "فیلد درجه الزامی هست." },
                DrpPart: { required: "لطفا بخش مورد نظر را انتخاب کنید." }


                // messages:function(color,element){ color.css('color','red')}
            }


        })
    });

    $(".users").click(function () {

        $(".form-users").validate({
            errorClass: 'bashe',
            rules: {
                 
                //<%=inpName.UniqueID %>: {
                //    required: true,
                //},
                inpFamily: {
                    required: true,
                },
                inpUser: {
                    required: true,
                }
                ,
                inpPass: {
                    required: true,
                 
                }
                ,
                FileUpload: {
                    required: true,
                }
            },

            messages: {
                 //<%=inpName.UniqueID %>: { required: "فیلد نام الزامی هست." },
                inpFamily: { required: "فیلد فامیلی الزامی هست." },

                inpUser: { required: "فیلد موبایل الزامی هست.", minlength: "لطفا موبایل را صحیح وارد کنید." },
                inpPass: { required: "فیلد تخصص الزامی هست" },
                FileUpload: { required: "فیلد درجه الزامی هست." }
              


                // messages:function(color,element){ color.css('color','red')}
            }


        })
    });

     function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

         return true;
      }
   
});



