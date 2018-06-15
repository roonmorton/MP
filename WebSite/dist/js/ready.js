$(document).ready(function () {
   /**Funciones de inicio**/
   datosPersonalesFn();
   menuFn();
   cumpleanerosFn();
   diasVacacionesFn();
   favoritosFn();
   cumpleanerosFn();
   //saldoCafeteriaFn();

   /***Controles de usuario especiales**/
   $('.fecha').mask('99/99/9999');
   $('.fecha').datetimepicker({
      locale: 'es'
        , format: 'L'
   });

   $('.campoObligatorio').attr('required', 'required');
   $('.campoSoloLectura').attr('readonly', 'readonly');

   $(".numero").keydown(function (e) {
      // Allow: backspace, delete, tab, escape, enter and .
      if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
      // Allow: Ctrl+A, Command+A
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
      // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
         // let it happen, don't do anything
         return;
      }
      // Ensure that it is a number and stop the keypress
      if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
         e.preventDefault();
      }
   });

   $(".modal-wide").on("show.bs.modal", function () {
      var height = $(window).height() - 200;
      $(this).find(".modal-body").css("max-height", height);
   });



   /**busqueda en el menú**/
   $('#btnMenuBuscar').click(function () {
         if ($('#txtMenuBuscar').val().trim() !== "") {
         buscarMenu($('#txtMenuBuscar').val().trim());
      }
   });

   $('#txtMenuBuscar').bind("enterKey", function (e) {
      if ($('#txtMenuBuscar').val().trim() !== "") {
         buscarMenu($('#txtMenuBuscar').val().trim());
      }
   });
   $('#txtMenuBuscar').keyup(function (e) {
      if (e.keyCode == 13) {
         $(this).trigger("enterKey");
      }
   });

   /**Aplica estilos bootstrap a controles de usuario**/
   
   $('input[type="text"],[type="number"],[type="email"],[type="password"],[type="date"],[type="datetime-local"],select').addClass("form-control");
   $('table[id *=grd],table[id *=Grd],table[id *=GRD]').addClass("table  table-condensed table-bordered table-hovered ").css("background-color", "#FFF");
   

   $('#myForm').validator();

});     //Fin de document.ready(){}