let urlApi = "https://apiseriespersonajes.azurewebsites.net/";

$(document).ready(function () {
    cargarSeries();
});

function cargarSeries() {
    var request = "api/Series";
    $.ajax({
        url: urlApi + request,
        type: "GET",
        contentType: "application/json",
        success: function (data) {
            var html = "";
            $.each(data, function (index, serie) {
                html += '<li><a class="dropdown-item" href="serie.html?idSerie=' + serie.idSerie + '">' + serie.nombre + '</a></li>';
            });
            $("#listaSeries").append(html);
        }
    });
}


