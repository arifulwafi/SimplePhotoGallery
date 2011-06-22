//If window height equals to page height then get next page
$(window).scroll(function () {
    GetNextPage();              //append new page
})

function GetNextPage() {
    if ($('body').height() <= ($(window).height() + $(window).scrollTop()) && $('#isLock').val() == 0) {
        $('#isLock').val(1);        //stop new event to fire
        $("#spinner").show();       //show spinner image
        var id = $("#pageCount").val();
        var albumID = $("#albumID").val();
        $.getJSON("/Photo/GetPhotos?albamId=" + albumID + "&pageno=" + id, null, function (data) {
            $.each(data, function () {
                var accessType = "";
                $('#grid').append("<li style=\"font-size:" + $("#grid_slider").slider("option", "value") + "px\"><a class=\"cboxElement\" rel=\"slideshow\" title=\"" + this.Title + "(" + accessType + ")" + "\" href=\"/Media/" + GetFileName(this) + "\"><img height=\"300\" width=\"300\" alt=\"\" style=\"width: 3em; height: 3em;\" src=\"/Media/" + GetFileName(this) + "\"></a></li>");
            });
            //We have responce from server
            $("#spinner").hide(); //Hide spinner
            $('#isLock').val(0); //Unlock new event
            $('#itemCount').html($('#grid > li').size());
            $("a[rel='slideshow']").colorbox({ slideshow: true });
        });
        id++;
        $("#pageCount").val(id)
    }
}

function GetFileName(item) {
    var virtualPath = "";
    if (item.PhotoFile != null) {
        !(item.PhotoFile.Name && item.PhotoFile.Name == '') ? virtualPath = "~/Media/Album/" + item.AlbumId + item.Id + "-420" + item.PhotoFile.Extension : virtualPath = "photo-420.png";
    }
    return virtualPath;
}