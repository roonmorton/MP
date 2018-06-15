function datosPersonales(callbackFn) {
   //var parametros = JSON.stringify({ 'inicioPeriodo': inicioPeriodo, 'zona': zona, 'finca': finca, 'opcion': opcion });
   $.ajax({
      url: '/SDmaster/masterservices.asmx/datosGenerales',
      type: 'POST',
      /*dataType: "text json",*/
      contentType: "application/json; charset=utf-8",
      success: function (msg) {
         callbackFn(msg);
      },
      error: function (xhr, status) {
         alertify.error('Ha ocurrido un error al contactar con el servidor');
         console.log(xhr);
      }
   });
}

function diasVacaciones(callbackFn) {
   //var parametros = JSON.stringify({ 'inicioPeriodo': inicioPeriodo, 'zona': zona, 'finca': finca, 'opcion': opcion });
   $.ajax({
      url: '/SDmaster/masterservices.asmx/diasVacaciones',
      type: 'POST',
      /*dataType: "text json",*/
      contentType: "application/json; charset=utf-8",
      success: function (msg) {
         callbackFn(msg);
      },
      error: function (xhr, status) {
         alertify.error('Ha ocurrido un error al contactar con el servidor');
         console.log(xhr);
      }
   });
}


function saldoCafeteria(callbackFn) {
   //var parametros = JSON.stringify({ 'inicioPeriodo': inicioPeriodo, 'zona': zona, 'finca': finca, 'opcion': opcion });
   $.ajax({
      url: '/SDmaster/masterservices.asmx/saldoCafeteria',
      type: 'POST',
      /*dataType: "text json",*/
      contentType: "application/json; charset=utf-8",
      success: function (msg) {
         callbackFn(msg);
      },
      error: function (xhr, status) {
         console.log(xhr);
         alertify.error('Ha ocurrido un error al contactar con el servidor');
      }
   });
}

function menu(callbackFn) {
   //var parametros = JSON.stringify({ 'inicioPeriodo': inicioPeriodo, 'zona': zona, 'finca': finca, 'opcion': opcion });
   $.ajax({
      url: '/SDmaster/masterservices.asmx/menu',
      type: 'POST',
      /*dataType: "text json",*/
      contentType: "application/json; charset=utf-8",
      success: function (msg) {
         callbackFn(msg);
      },
      error: function (xhr, status) {
         console.log(xhr);
       alertify.error('Ha ocurrido un error al contactar con el servidor');
      }
   });
}

function cumpleaneros(callbackFn) {
   $.ajax({
      url: '/SDmaster/masterservices.asmx/cumpleaneros',
      type: 'POST',
      /*dataType: "text json",*/
      contentType: "application/json; charset=utf-8",
      success: function (msg) {
         callbackFn(msg);
      },
      error: function (xhr, status) {
         console.log(xhr);
         alertify.error('Ha ocurrido un error al contactar con el servidor');
      }
   });
}

function favoritos(callbackFn) {
   $.ajax({
      url: '/SDmaster/masterservices.asmx/favoritos',
      type: 'POST',
      /*dataType: "text json",*/
      contentType: "application/json; charset=utf-8",
      success: function (msg) {
         callbackFn(msg);
      },
      error: function (xhr, status) {
         console.log(xhr);
         alertify.error('Ha ocurrido un error al contactar con el servidor');
      }
   });
}

function busqueda(criterio, callbackFn) {
   if (criterio.trim() == "") { 
      criterio = "-1"
   }
   var parametros = JSON.stringify({ 'criterio': criterio});
   $.ajax({
      url: '/SDmaster/masterservices.asmx/busqueda',
      data:parametros,
      type: 'POST',
      /*dataType: "text json",*/
      contentType: "application/json; charset=utf-8",
      success: function (msg) {
         callbackFn(msg);
      },
      error: function (xhr, status) {
         console.log(xhr);
         alertify.error('Ha ocurrido un error al contactar con el servidor');
      }
   });
}

