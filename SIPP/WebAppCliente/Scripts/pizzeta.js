var numPizza = 1;
var pizzaScroll = false;
var pizzaDragg = '';
$(document).ready(function () {
    //CONTENEDORES DE LOS INGREDIENTES (partes de pizza)

    function setPizzaFunctions() {
        $(".cuartoPizza").droppable({
            accept: ".ingredientItem",
            drop: function (event, ui) {
                var dropped = ui.draggable;
                var droppedOn = $(this);
                var rotationClass = "";
                ingredienteDelete = "";
                //Vemos la rotación que debemos asignarle
                switch (droppedOn.attr("id")) {
                    case "pizzaUpLeft":
                        rotationClass = "upLeftItem";
                        break;
                    case "pizzaUpRight":
                        rotationClass = "upRightItem";
                        break;
                    case "pizzaDownLeft":
                        rotationClass = "downLeftItem";
                        break;
                    case "pizzaDownRight":
                        rotationClass = "downRightItem";
                        break;
                }


                var idParte = droppedOn.attr("id");
                //Vemos que ingrediente le ponemos
                var ingrediente = dropped.attr("id").replace('Icon', '');
                var ingredienteCapitalized = ingrediente.charAt(0).toUpperCase() + ingrediente.slice(1);

                if ((document.getElementById(idParte + numPizza + ingredienteCapitalized)) == null) {
                    $(this).append('<div id="' + idParte + numPizza + ingredienteCapitalized + '" class="ingrediente ' + ingrediente + ' ' + rotationClass + '"></div>');
                    $('#' + idParte + numPizza + ingredienteCapitalized).fadeIn();

                    if ((document.getElementById('resumen' + ingredienteCapitalized)) == null) {
                        var nombre = dropped.attr('title');
                        $('#resumenIngredientes').append('<tr id="resumen' + ingredienteCapitalized + '"><td>' + nombre + '</td><td id="resumen' + ingredienteCapitalized + 'Count">0</td></tr>');
                    }
                    //recalculamos la tabla de ingredientes
                    recalcularIngredientes();
                }
            },
            over: function (event, elem) {
                $(this).addClass("over");
            },
            out: function (event, elem) {
                $(this).removeClass("over");
            },
            deactivate: function (event, elem) {
                $(this).removeClass("over");
            }

        });

        var detallesDisplayed = false;
        $('#pizza' + numPizza + ' .cuartoPizza').click(function () {
            if (!detallesDisplayed) {
                detallesDisplayed = true;
                $('#detallesRow').html('');//vaciamos el div
                $('#modal').toggle(200, function () {
                    $('#detallesArea').toggle('slide', 500, function () {
                        $('.detallesItemTd').draggable({
                            axis: "y",
                            distance: 50,
                            cursor: "pointer",
                            appendTo: "body",
                            scroll: false,
                            stop: function () {
                                var ingrediente = $('#' + $(this).find('.detallesItem').attr('id').replace('Icon', ''));
                                $(ingrediente).fadeOut(function () {
                                    $(ingrediente).remove();
                                    recalcularIngredientes();
                                });
                                $(this).fadeOut(function () {
                                    $(this).remove();
                                });
                            }
                        });
                    });
                });
            }
        });
        var prevX = -1;

        $('#pizzasContainer').draggable({
            axis: "x",
            distance: 30,
            cursor: "pointer",
            appendTo: "body",
            scroll: true,
            drag: function (e) {
                if (prevX == -1) {
                    prevX = e.pageX;
                    return false;
                }
                // dragged left
                if (prevX > e.pageX) {
                    pizzaDragg = 'izquierda';
                }
                else if (prevX < e.pageX) { // dragged right
                    pizzaDragg = 'derecha'
                }
                prevX = e.pageX;
            },
            stop: function () {
                if (!pizzaScroll) {
                    pizzaScroll = true;
                    if (pizzaDragg == 'derecha') {
                        if (numPizza > 1) {
                            numPizza--;
                        }
                        scrollPizzas('anterior');
                    } else {
                        if ($('.pizza').length > numPizza) {
                            numPizza++;
                        }
                        scrollPizzas('siguiente');
                    }
                }
            }
        });

        $('#modal').click(function () {
            if (detallesDisplayed) {
                detallesDisplayed = false;
                $('#detallesArea').toggle('slide', 500, function () {
                    $('#modal').toggle(200);
                });
            }
        })
        .children().click(function (e) {
            if (!$(this).hasClass('ayuda')) {
                return false;
            }
        });

        //PARTES DE PIZZA
        $('#pizza' + numPizza + ' .pizzaUpLeft').click(function () {
            desplegarIngredientes('upLeftItem');
        });

        $('#pizza' + numPizza + ' .pizzaUpRight').click(function () {
            desplegarIngredientes('upRightItem');
        });

        $('#pizza' + numPizza + ' .pizzaDownLeft').click(function () {
            desplegarIngredientes('downLeftItem');
        });

        $('#pizza' + numPizza + ' .pizzaDownRight').click(function () {
            desplegarIngredientes('downRightItem');
        });
    }


    setPizzaFunctions();

    //INGREDIENTES DE LA LISTA
    $('.ingredientItem').draggable({ containment: ".editor", cursor: "pointer", revert: "invalid", appendTo: "body", scroll: false, opacity: 0.9, helper: "clone" });

    $('#addPizza').click(function () {
        if (!pizzaScroll) {
            pizzaScroll = true;
            numPizza = $('.pizza').length + 1;

            $('#pizzasContainer').append('<td class="tablaPizza"><div id="pizza' + numPizza + '" class="pizza"><table class="tablaIngredientes" cellspacing="0"><tr><td id="pizzaUpLeft" class="cuartoPizza pizzaUpLeft"></td><td id="pizzaUpRight" class="cuartoPizza pizzaUpRight"></td></tr><tr><td id="pizzaDownLeft" class="cuartoPizza pizzaDownLeft"></td><td id="pizzaDownRight" class="cuartoPizza pizzaDownRight"></td></tr></table></div></td>');

            //scroll hasta la nueva pizza
            $('.pizzaArea').animate({ scrollLeft: numPizza * 950 }, '500', 'swing', function () {
                pizzaScroll = false;
            });
            setPizzaFunctions();
        }
    });

    $('#deletePizza').click(function () {
        if (!pizzaScroll) {
            pizzaScroll = true;
            if ($('.pizza').length > 1) {
                var borrar = confirm("¿Desea eliminar esta pizza?");
                if (borrar) {
                    $('#pizza' + numPizza).parent().effect('scale', { percent: -100 }, 2000, function () {
                        $('.pizzaArea').animate({ scrollLeft: 0 }, '500', 'swing', function () {
                            numPizza = 1;
                            pizzaScroll = false;
                        });

                        $(this).remove();

                        //recalculamos la tabla de ingredientes
                        recalcularIngredientes();

                        //reordenamos indices
                        $('.pizza').each(function (index, element) {
                            $(element).attr("id", "pizza" + (index + 1));
                        });
                    });
                    //$('#pizza'+numPizza).parent().remove();
                } else {
                    pizzaScroll = false;
                }
            } else {
                $('#pizza' + numPizza).parent().effect('shake', 500, function () {
                    pizzaScroll = false;
                });
            }
            //scrollPizzas('anterior');
        }
    });

    $('#nextPizza').click(function () {
        if (!pizzaScroll) {
            if ($('.pizza').length > numPizza) {
                pizzaScroll = true;
                numPizza++;
                scrollPizzas('siguiente');
            }
        }
    });

    $('#beforePizza').click(function () {
        if (!pizzaScroll) {
            if (numPizza > 1) {
                pizzaScroll = true;
                numPizza--;
                scrollPizzas('anterior');
            }
        }
    });

    var resumenDesplegado = false;
    $('#desplegarResumen')
        .mouseover(function () {
            if (!resumenDesplegado) {
                resumenDesplegado = true;
                $('#resumenArea').slideDown(500, function () {
                    resumenDesplegado = false;
                });
            }
        });

    $('#resumenArea').mouseleave(function () {
        // if (resumenDesplegado) {
        $('#resumenArea').slideUp(500);
        // }
    });

    $('.pizzaArea').mouseover(function () {
        // if (resumenDesplegado) {
        $('#resumenArea').slideUp(500);
        // }
    });


    recalcularIngredientes();
});

function scrollPizzas(direccion) {
    var scrollActual = $('.pizzaArea').scrollLeft();
    if (direccion == 'anterior') {
        $('.pizzaArea').animate({ scrollLeft: scrollActual - 950 }, '500', 'swing', function () {
            pizzaScroll = false;
        });
    } else {
        $('.pizzaArea').animate({ scrollLeft: scrollActual + 950 }, '500', 'swing', function () {
            pizzaScroll = false;
        });
    }
}

function scrollIngredientes(direccion, distancia) {
    var scrollActualVertical = $('.ingredients').scrollTop();
    var scrollActualHorizontal = $('.detalles').scrollLeft();

    switch (direccion) {
        case 'up':
            $('.ingredients').animate({ scrollTop: scrollActualVertical - distancia }, '500', 'swing');
            break;
        case 'down':
            $('.ingredients').animate({ scrollTop: scrollActualVertical + distancia }, '500', 'swing');
            break;
        case 'left':
            $('.detalles').animate({ scrollLeft: scrollActualHorizontal - distancia }, '500', 'swing');
            break;
        case 'right':
            $('.detalles').animate({ scrollLeft: scrollActualHorizontal + distancia }, '500', 'swing');
            break;
    }
}

function desplegarIngredientes(clase) {
    //obtenemos el array de ingredientes
    var items = $('#pizza' + numPizza + ' .' + clase).toArray();
    /*//Ordenamos los ingredientes por el z-index
    items = items.sort(function(a, b) {
        return(Number($(a).zIndex()) - Number($(b).zIndex()));
    });*/
    items.forEach(function (aItem) {
        var classList = aItem.className.split(/\s+/);
        $('#detallesRow').append('<td class="detallesItemTd"><div class="detallesItem ' + classList[1] + 'Icon" id="' + aItem.id + 'Icon"></div><td>');
    });
}

function recalcularIngredientes() {
    $('#resumenIngredientes').html('<tr><th>Descripci&oacute;n</th><th>Precio</th></tr></tr>');//reiniciamos la tabla
    var precioTotal = 0;

    $('#resumenIngredientes').append('<tr id="resumenPizza"></tr>');
    var precioUnit = $('#addPizza').attr('precio');
    var totalIngrediente = ($('.pizza').length) * precioUnit;
    precioTotal = precioTotal + totalIngrediente;
    var cuartos = $('.pizza').length;
    if (cuartos == 1) {
        cuartos += " Pizzeta";
    } else {
        cuartos += " Pizzetas";
    }
    $('#resumenPizza').html('<td>' + cuartos + '</td><td>' + totalIngrediente + '</td>');

    $('.ingrediente').each(function (index, element) {
        var ingrediente = (element.className.split(/\s+/))[1];
        var ingredienteCapitalized = ingrediente.charAt(0).toUpperCase() + ingrediente.slice(1);
        var nombre = $('#' + ingrediente + 'Icon').attr('title');
        if (document.getElementById('resumen' + ingredienteCapitalized) == null) {
            $('#resumenIngredientes').append('<tr id="resumen' + ingredienteCapitalized + '"></tr>')
            cuartos = contarCuartos(ingrediente);
            precioUnit = $('#' + ingrediente + 'Icon').attr('precio');
            totalIngrediente = ($('.' + ingrediente).length) * precioUnit;
            precioTotal = precioTotal + totalIngrediente;
            $('#resumen' + ingredienteCapitalized).html('<td>' + cuartos + ' ' + nombre + '</td><td>' + totalIngrediente + '</td>');
        }
    });
    $('#resumenIngredientes').append('<tr id="rowTotal"><td style="text-align:right">Total:</td><td id="precioTotal">' + precioTotal + '</td>');
    $('#totalPreview').html(precioTotal);
}

function contarCuartos(ingrediente) {
    var count = $('.' + ingrediente).length;
    var cuartos = '';

    if (count < 4) {
        if (count != 2) {
            cuartos = count + '/4 pizzeta';
        } else {
            cuartos = '1/2 pizzeta';
        }
    } else if (count % 4 == 0) {
        cuartos = (count / 4);
        if (cuartos == 1) {
            cuartos += ' pizzeta';
        } else {
            cuartos += ' pizzetas';
        }
    } else {
        cuartos = parseInt((count / 4), 0);
        if (cuartos == 1) {
            var metros = ' pizzeta';
        } else {
            var metros = ' pizzeta';
        }
        cuartos += ' ' + (count % 4) + '/4 ' + metros;
    }

    return cuartos;
}