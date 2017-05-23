var Admin = {
    ConfirmArticle: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/Article/ConfirmArticle";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                table_ds.innerHtml = '';
                $("#table_ds").load("/Admin/Article/Index #table1");
            }
        });
    },
    DeleteArticleSuccess: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/Article/DeleteArticle";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                table_ds.innerHtml = '';
                $("#table_ds").load("/Admin/Article/SuccessArticle #table1");
            }
        });
    },
    DeleteArticleWaiting: function (Id) {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/Article/DeleteArticle";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                table_ds.innerHtml = '';
                $("#table_ds").load("/Admin/Article/Index #table1");
            }
        });
    },
    RestoreArticle: function (Id)
    {
        var dataRequest = {
            id: Id
        };

        var url = "Admin/Article/RestoreArticle";

        common.CallXhttp(url, typeAjax.Post, dataTypeAjax.Html, dataRequest, true, true, function (data) {
            if (data == null) {

            }
            else {
                table_ds.innerHtml = '';
                $("#table_ds").load("/Admin/Article/ArticleSave #table1");
            }
        });
    }
}