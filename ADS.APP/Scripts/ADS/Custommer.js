var Custommer = {
    ViewCreate: function () {

        var dataRequest = {
            
        };

        var url = "Admin/Custommer/Add";

        common.CallXhttp(url, typeAjax.Get, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                $("#modal_md").html(data);
                $("#modal_md").modal("show");
            }
        });
    },
}
var Category = {
    ViewCreate: function () {
        var dataRequest = {

        };

        var url = "Admin/Category/Add";

        common.CallXhttp(url, typeAjax.Get, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                $("#tempContainer_sm").html(data);
                $("#tempModal_sm").modal("show");
            }
        });
    },
    OnSuccess: function (data, refType) {
        common.EndLoading();
        if (data.Code == "00") {
            var View = $("#View").val();

            Mapping_Process.LoadDic(refType, Mapping_Process.PageIndex);
            common.Message("Thông báo", data.Mes, "success");

            $("#modal_sm").modal("hide");
        }
        else {
            common.Message("Thông báo", data.Mes, "warning");
        }
    },
    LoadDic: function (refType, PageIndex) {
        var urlApi = "Admin/Mapping/MappingGet";
        Mapping_Process.PageIndex = PageIndex;
        common.CallXhttp(
            urlApi,
            typeAjax.Get,
            dataTypeAjax.Html,
            { PageIndex: PageIndex },
            true,
            true,
            function (data) {
                $("#ListDic").html(data);
            });
    },
}