var Admin = {
    ConfirmArticle: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/AdminArticle/ConfirmArticle";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                $("#tempModal_lg").modal("hide");
                table_ds.innerHtml = '';
                $("#table_ds").load("/Admin/AdminArticle/Index #table1");
            }
        });
    },
    DeleteArticleSuccess: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/AdminArticle/DeleteArticle";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                table_ds.innerHtml = '';
                $("#table_ds").load("/Admin/AdminArticle/SuccessArticle #table1");
            }
        });
    },
    DeleteArticleWaiting: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/AdminArticle/DeleteArticle";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                table_ds.innerHtml = '';
                $("#table_ds").load("/Admin/AdminArticle/Index #table1");
            }
        });
    },
    RestoreArticle: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/AdminArticle/RestoreArticle";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                table_ds.innerHtml = '';
                $("#table_ds").load("/Admin/AdminArticle/ArticleSave #table1");
            }
        });
    },
    DeleteCus: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/Custommer/DeleteCus";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                div.innerHtml = '';
                $("#div").load("/Admin/Custommer/Index #table_cus");
            }
        });
    },
    //Staff
    StaffCreate: function () {
        var dataRequest = {

        };

        var url = "Admin/Staff/StaffCreate";

        common.CallXhttp(url, typeAjax.Get, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                $("#tempContainer").html(data);
                $("#tempModal_md").modal("show");
            }
        });
    },
    DeleteStaff: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/Staff/DeleteStaff";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                div.innerHtml = '';
                $("#div").load("/Admin/Staff/Index #table_staff");
            }
        });
    },
    EditStaff: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/Staff/ViewDetails";

        common.CallXhttp(url, typeAjax.Get, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                $("#tempContainer").html(data);
                $("#tempModal_md").modal("show");
            }
        });
    },
    //End_Staff
    ViewDetailArticle: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/AdminArticle/ViewDetails";

        common.CallXhttp(url, typeAjax.Get, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                $("#tempContainer_lg").html(data);
                $("#tempModal_lg").modal("show");
            }
        });

    }


}