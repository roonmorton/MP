function datosPersonalesFn(){
    datosPersonales(function (data) {
        data = JSON.parse(data.d)
        if (data !== null) {
            $('#nombreCorto').text(data[0]["nombreCorto"]);
            $('#usuario').html(data[0]["nombreLargo"] + ' ' + data[0]["puesto"] + '<small>usuario desde ' + data[0]["fechaDeIngreso"] + '</small>');
            $('#avatarImage').attr('src', data[0]["urlImagen"].trim())
            $('#avatarImg').attr('src', data[0]["urlImagen"].trim())
        }
    });
}

function diasVacacionesFn(){
    diasVacaciones(function (data) {
        data = JSON.parse(data.d)
        if (data !== null) {
            $('#vacacionesSpan').text(data[0]["diasVacaciones"]);
        }

    });
}


function saldoCafeteriaFn(){
    saldoCafeteria(function (data) {
        data = JSON.parse(data.d)
        if (data !== null) {
            $('#saldoPrepagoSpan').text(data[0]["diasVacaciones"]);
            $('#saldoCreditoSpan').text(data[0]["diasVacaciones"]);
        }

    });
}


function menuFn(){
    var menuHtml ='<ul class="sidebar-menu">'+
        '<li class="header">Menú Principal</li>';
    var subMenu ='';

    menu(function (data) {

        data = JSON.parse(data.d)
        if (data !== null) {
            $('#menuDiv').html('<i class="fa fa-circle-o-notch" aria-hidden="true"></i>');
            /* var nodos =  _.filter(data, (nodo) => {
      //return user.age >= minAge && user.age <= maxAge;
      return nodo.ParentId.toLowerCase()=='0  ';
               });
      */

            var nodos =  _.filter(data, function(nodo) {
                return nodo.ParentId.toLowerCase()=='0  ';
            });

            for(i=0;i<nodos.length;i++){
                menuHtml +=   '<li class="treeview">'+
                    '<a href="#" title="' + nodos[i]["Texto"] + '">'+
                    '<i class="fa fa-circle-o text-blue"></i><span>'+ nodos[i]["Texto"]+'</span>'+
                    '<span class="pull-right-container">'+
                    '<i class="fa fa-angle-left pull-right"></i>'+
                    '</span>';
                menuHtml+=nodosHijo(data,nodos[i]["MenuId"]);
                menuHtml+='</a>'+
                    '</li>';
            }

            menuHtml +='</ul>';

            $('#menuDiv').html(menuHtml);
            $("#menuDiv").mCustomScrollbar({
                setHeight: 350,
                setWidth: false,
                theme: "light-thin",
                axis: "yx"
            });

        }

    });
}

function nodosHijo(arr,valorBusqueda){
    var subMenu = "";
    /*var nodos =  _.filter(arr, (nodo) => {
   return nodo.ParentId.trim() == valorBusqueda.trim();
            });
            */
    var nodos =  _.filter(arr, function(nodo){
        return nodo.ParentId.trim() == valorBusqueda.trim();
    });

    //for(j=0;j<nodos.length;j++){ 
    //if (j==0){ subMenu  = '<ul class="treeview-menu">';}
    subMenu  = '<ul class="treeview-menu">';
    $.each(nodos,function(index,nodo){
        //Determina si es un sub menú o si es un enlace 
        if(nodo["URL"].trim()==''){
            url = "#";
            subMenu +='<li><a href="' + url + '" title="' + (nodo["ToolTip"]==null?nodo["Texto"]:nodo["ToolTip"])  + '"><i class="fa fa-circle-o text-red"></i><span>'+nodo["Texto"]+'</span>'+
                ' <span class="pull-right-container"> <i class="fa fa-angle-left pull-right"></i> </span></a>';
            subMenu+=nodosHijo(arr,nodo["MenuId"]);
            subMenu +='</li>';
        }
        else{
            url=nodo["URL"].trim();
            subMenu +='<li><a target="_blank" href="' + url + '" title="' + (nodo["ToolTip"]==null?nodo["Texto"]:nodo["ToolTip"]) +'"><i class="fa fa-link text-yellow"></i><span>'+nodo["Texto"]+'</span></a></li>';
        }

        //if (j==nodos.length-1){ subMenu+='</ul>';}
    });
    subMenu+='</ul>';  
    return subMenu;
}

function favoritosFn(){
    favoritos(function (data) {
        if (data.d !== '') {
            data = JSON.parse(data.d)
        }
        else{
            data = "";
        }
        var html = '';

        if (data !== '') {
            html = '<ul class="sidebar-menu">'+
                '<li class="header">Favoritos</li>';
            for(i=0;i<data.length;i++){
                html +=   '<li class="treeview">'+
                    '<a target="_blank" href="'+ data[i]["ruta"] + '" title="' + data[i]["Nombre"] + '">'+
                    '<i class="fa fa-star text-yellow"></i><span>'+ data[i]["Nombre"]+'</span>'+
                    '<span class="pull-right-container">'+
                    '<i class="fa fa-angle-left pull-right"></i>'+
                    '</span>'+
                    '</a>'+
                    '</li>';
            }

            html +='</ul>';
        }

        $('#favoritosDiv').html(html);
        $("#favoritosDiv").mCustomScrollbar({
            setHeight: 150,
            setWidth: false,
            theme: "light-thin",
            axis: "yx"
        });
    });
}

function cumpleanerosFn(){
    cumpleaneros(function (data) {
        if (data.d !== '') {
            data = JSON.parse(data.d)
        }
        else{
            data = "";
        }
        var html = '';

        if (data !== '') {
            html='<ul class="control-sidebar-menu">';
            $.each(data,function(index,item){
                html+='<li>'+
                    '<a href="javascript:void(0)">'+
                    '<i class="menu-icon fa fa-user bg-yellow"></i>'+
                    '<div class="menu-info">'+
                    '<h4 class="control-sidebar-subheading">' + item["nombre"]+'</h4>'+
                    '<p>Cumplirá años el '+item["cumpleanos"]+'</p>'+
                    '</div>'+
                    '</a>'+
                    '</li>';
            });
            html+='</ul>';
        }
        else{
            html='<div class ="text-center">No hay cumpleañeros</div>';
        }
        $('#cumpleanerosDiv').html(html);
    });
}

function buscarMenu(criterio) {
    $('#busquedaDiv').html('<div class="text-center"><i class="fa fa-spinner fa-pulse fa-4x fa-fw text-center"></i><span class="sr-only text-center">Cargando...</span></div> ');
    $('#modalBusqueda').modal();
    busqueda($('#txtMenuBuscar').val().trim(),function(data){
        var html = "";
        if(data.d !== '') {
            data = JSON.parse(data.d);
            $.each(data,function(i,item){
                html +='<a href="' + item["URL"] +   '" target="_blank">' + item["Texto"]  + '</a><br>' +
                    '<cite>' + item["URL"] + '</cite>'+
                    '<div class="descripcion">' + (item["ToolTip"] == null ? '' : item["ToolTip"]) + '</div><br>';
            });
        }
        else{
            html='<div class="text-center">Sin resultados que mostrar &nbsp;<i class="fa fa-frown-o" aria-hidden="true"></i></div>';
        }

        $('#busquedaDiv').html(html);
        $('#palabraClaveSpan').text(criterio);
        $('#registrosBadge').html('<span class="badge">'+ (data.length==null?'0':data.length) + '</span>');
    });
}

