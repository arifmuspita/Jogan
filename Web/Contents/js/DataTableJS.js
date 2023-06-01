var DataTableJS = function () {
    var CreateDataTables2 = function (webroot, modul, submodul, id, url, newaction, columndefs, columns) {
        //console.log("aaa");
        var table = null;
        var url_ = "";
        if (webroot != "") { webroot = "/" + webroot; }
        url_ = webroot + "/Ajax/GetDataTableList/" + submodul + "/get/all";
        if (id != 0) { url_ = webroot + "/Ajax/GetDataTableList/" + submodul + "/get/" + id; }
        if (url != "") { url_ = url; }
        if ($("#" + submodul + "_table")) {
            if (!$.fn.DataTable.isDataTable("#" + submodul + "_table")) {
                table = $("#" + submodul + "_table").DataTable({
                    "lengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
                    "iDisplayLength": 10,
                    "processing": true,
                    "serverSide": true,
                    "ajax":
      {
          "url": url_,
          "type": "GET",
          "datatype": "json"
      },
                    "columnDefs": columndefs,
                    "columns": columns,
                    "pagingType": "full_numbers",
                });
            }
        }
        return table;
    }



    return {
        //CreateDataTables: function (modul, submodul, id, url, newaction) {
        //    return CreateDataTables(modul, submodul, id, url, newaction);
        //},
        CreateDataTables2: function (webroot, modul, submodul, id, url, newaction, columndefs, columns) {
            return CreateDataTables2(webroot, modul, submodul, id, url, newaction, columndefs, columns);
        },
    }
}();