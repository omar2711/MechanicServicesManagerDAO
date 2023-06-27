<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="loadMap.aspx.cs" Inherits="MechanicWEBF.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript" src="https://www.bing.com/api/maps/mapcontrol?callback=loadMap" async defer></script>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script type="text/javascript">
    $(document).ready(function() {
        loadMap();
    });
    </script>

    <script type="text/javascript">

        var markers = [];



function loadMap() {
    var map = new Microsoft.Maps.Map('#mapContainer', {
        credentials: 'AlNapWkF5mpkg9NSaNE4vM0BmjQeG8JsxPVtnUIY_OKwceBDLDoilIFhc7AZoZwJ'
    });

    var marker = new Microsoft.Maps.Pushpin(map.getCenter(), {
        draggable: true
    });

    map.entities.push(marker);

    Microsoft.Maps.Events.addHandler(marker, 'dragend', function(e) {
        var entity = e.entity || e.target;
        
        if (entity) {
            var newPosition = entity.getLocation();

            var latitude = newPosition.latitude;
            var longitude = newPosition.longitude;

            alert('Latitud: ' + latitude + ', Longitud: ' + longitude);

            $.ajax({
                type: 'POST',
                url: 'Branch.aspx/GuardarCoordenadas',
                data: JSON.stringify({ latitude: latitude, longitude: longitude }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function(response) {
                    var url = 'Branch.aspx?latitude=' + latitude + '&longitude=' + longitude;
                    window.location.href = url;
                },
                error: function(error) {
                }
            });
        }
    });

}





                
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    
<div style="margin-top: 100px;">
  <div style="display: flex; flex-direction: column;">
    <div id="mapContainer" style="width: 100%; height:100%;"></div>
  </div>
</div>



</asp:Content>
