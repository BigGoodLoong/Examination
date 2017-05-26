//关机效果,弹出居中层
function AlterDivAndClose(alertDivId, buttonOpenID, buttonCloseID) {

    $('html').css({ margin: 0, width: "100% ", height: "100%" });
    $('body').css({ margin: 0, width: "100% ", height: "100%" });

    var radDivName = 'blockUI' + (parseInt(Math.random() * (10000 - 1000 + 1) + 10000)); //随机ID
    $('body').append("<div  id='" + radDivName + "'></div>"); //遮罩DIV 
    alertDivId = "#" + alertDivId;
    buttonOpenID = "#" + buttonOpenID;
    buttonCloseID = "#" + buttonCloseID;
    radDivName = "#" + radDivName;

    $(alertDivId).css({ left: 0, top: 0, "z-index": "1249", "display": "none" }); //层的样式 

    //开***********************
    $(buttonOpenID).click(function () {
        //****弹出层的高和宽
        var divWidth = $(alertDivId).width()
        var divHeight = $(alertDivId).height();
        //****网页所有可用区的高宽
        var ScreenW = $(document).width(); //网页所有可用区宽
        var ScreenH = $(document).height();   //网页所有可用区高
        //****获取LEFT,TOP
        var v_left = (document.body.clientWidth - divWidth) / 2; //LEFT
        var v_top = (document.body.clientHeight - divHeight) / 2; //TOP 

        $(radDivName).css({ position: "absolute", "background-color": "#ccc", "display": "none", "z-index": "1238", top: 0, left: 0, opacity: 0.3, width: document.body.clientWidth, height: document.body.clientHeight });
        $(alertDivId).animate({ height: divHeight, opacity: 1.0, top: v_top, left: v_left }, 'slow');
        $(radDivName).show("slow");
    })
    //关***********************
    $(buttonCloseID).click(function () {
        $(alertDivId).css({ left: 0, top: 0, "z-index": "1249", "display": "none" });
        $(alertDivId).animate({ height: "0", opacity: 0.0, top: 0, left: 0, hide: 'hide' }, 'slow');
        $(radDivName).hide("slow");
    })

};

