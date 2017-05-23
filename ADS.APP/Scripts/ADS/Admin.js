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
    RestoreArticle: function (Id)
    {
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
    }
}