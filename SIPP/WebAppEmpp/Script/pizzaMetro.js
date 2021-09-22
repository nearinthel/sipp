var numCuarto = 1;
var pizzaScroll = false;
var pizzaDragg = '';
$(document).ready(function () {
    //CONTENEDORES DE LOS INGREDIENTES (partes de pizza)

    function setPizzaFunctions() {
        $(".pizza").droppable({
            accept: ".ingredientItem",
            drop: function (event, ui) {
                var dropped = ui.draggable;
                var droppedOn = $(this);
                ingredienteDelete = "";
                if ((droppedOn.attr('id').replace('pizza', '')) == numCuarto) {
                    //Vemos que ingrediente le ponemos
                    var ingrediente = dropped.attr("id").replace('Icon', '');
                    var ingredienteCapitalized = ingrediente.charAt(0).toUpperCase() + ingrediente.slice(1);

                    var clase = '';
                    if (numCuarto == 1) {
                        clase = 'ExtIzquierdo';
                    } else if (numCuarto > 1) {
                        clase = 'Centro';
                    }

                    if ($('.pizza').length == 1) {
                        clase = 'Cuarto';
                    } else if (numCuarto == $('.pizza').length) {
                        clase = 'ExtDerecho';
                    }

                    if ((document.getElementById(numCuarto + ingredienteCapitalized)) == null) {
                        $(this).append('<div id="' + numCuarto + ingredienteCapitalized + '" class="ingrediente ' + ingrediente + ' ingrediente' + clase + '"></div>');
                        $('#' + numCuarto + ingredienteCapitalized).fadeIn();

                        //recalculamos la tabla de ingredientes
                        recalcularIngredientes();
                    }
                } else {
                    $('#pizzas').effect('shake');
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
        $('#pizza' + numCuarto).click(function () {
            if ($(this).attr('id').replace('pizza', '') == numCuarto) {
                if (!detallesDisplayed) {
                    detallesDisplayed = true;
                    $('#detallesRow').html('');//vaciamos el div
                    $('#modal').toggle(200, function () {
                        $('#detallesArea').toggle('slide', 500, function () {
                            desplegarIngredientes();
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
            } else {
                $('#pizzas').effect('shake');
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
                        if (numCuarto > 1) {
                            numCuarto--;
                        }
                        scrollPizzas('anterior');
                    } else {
                        if ($('.pizza').length > numCuarto) {
                            numCuarto++;
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
    }


    setPizzaFunctions();

    //INGREDIENTES DE LA LISTA
    $('.ingredientItem').draggable({ containment: ".editor", cursor: "pointer", revert: "invalid", appendTo: "body", scroll: false, opacity: 0.9, helper: "clone" });

    $('#addPizza').click(function () {
        if (!pizzaScroll) {
            pizzaScroll = true;
            numCuarto = $('.pizza').length + 1;
            cuartoClass = 'ExtDerecho';
            $('#pizzasContainer').append(' <td id="tblPizza' + numCuarto + '" class="tablaPizza tablaPizza' + cuartoClass + '"><div id="pizza' + numCuarto + '" class="pizza pizza' + cuartoClass + '"></div></td>');

            $('.tablaPizza').each(function (index, element) {
                var clase = '';
                if (index == 0) {
                    clase = 'ExtIzquierdo';
                } else if (index < ($('.pizza').length - 1)) {
                    clase = 'Centro';
                } else if ((index + 1) == $('.pizza').length) {
                    clase = 'ExtDerecho';
                }

                if ($('.pizza').length == 1) {
                    clase = 'Cuarto';
                }

                $(element).removeClass('tablaPizzaExtIzquierdo tablaPizzaCuarto tablaPizzaCentro tablaPizzaExtDerecho');
                $(element).children().removeClass('pizzaExtIzquierdo pizzaCuarto pizzaCentro pizzaExtDerecho');
                $(element).addClass('tablaPizza' + clase);
                $(element).children().addClass('pizza' + clase);
                $(element).find('.ingrediente').each(function (index, element2) {
                    $(element2).removeClass('ingredienteExtIzquierdo ingredienteCuarto ingredienteCentro ingredienteExtDerecho');
                    $(element2).addClass('ingrediente' + clase);
                });
            });

            recalcularIngredientes();
            //scroll hasta la nueva pizza
            $('.pizzaArea').animate({ scrollLeft: numCuarto * 950 }, '500', 'swing', function () {
                pizzaScroll = false;
            });
            setPizzaFunctions();
        }
    });

    $('#deletePizza').click(function () {
        if (!pizzaScroll) {
            pizzaScroll = true;
            if ($('.pizza').length > 1) {
                var borrar = confirm("¿Desea eliminar este cuarto?");
                if (borrar) {
                    $('#pizza' + numCuarto).parent().effect('fade', 2000, function () {
                        $('.pizzaArea').animate({ scrollLeft: 0 }, '500', 'swing', function () {
                            numCuarto = 1;
                            pizzaScroll = false;
                        });
                        $(this).remove();

                        //recalculamos la tabla de ingredientes
                        recalcularIngredientes();

                        //reordenamos indices y corregimos clases
                        $('.tablaPizza').each(function (index, element) {
                            $(element).attr("id", "tblPizza" + (index + 1));
                            $(element).children().attr("id", "pizza" + (index + 1));

                            var clase = '';
                            if (index == 0) {
                                clase = 'ExtIzquierdo';
                            } else if (index < ($('.pizza').length - 1)) {
                                clase = 'Centro';
                            } else if ((index + 1) == $('.pizza').length) {
                                clase = 'ExtDerecho';
                            }
                            if ($('.pizza').length == 1) {
                                clase = 'Cuarto';
                            }
                            $(element).removeClass('tablaPizzaExtIzquierdo tablaPizzaCuarto tablaPizzaCentro tablaPizzaExtDerecho');
                            $(element).children().removeClass('pizzaExtIzquierdo pizzaCuarto pizzaCentro pizzaExtDerecho');
                            $(element).addClass('tablaPizza' + clase);
                            $(element).children().addClass('pizza' + clase);
                            $(element).find('.ingrediente').each(function (index, element2) {
                                $(element2).removeClass('ingredienteExtIzquierdo ingredienteCuarto ingredienteCentro ingredienteExtDerecho');
                                $(element2).addClass('ingrediente' + clase);
                            });
                        });
                    });
                } else {
                    pizzaScroll = false;
                }
            } else {
                $('#pizza' + numCuarto).parent().effect('shake', 500, function () {
                    pizzaScroll = false;
                });
            }
        }
    });

    $('#nextPizza').click(function () {
        if (!pizzaScroll) {
            if ($('.pizza').length > numCuarto) {
                pizzaScroll = true;
                numCuarto++;
                scrollPizzas('siguiente');
            }
        }
    });

    $('#beforePizza').click(function () {
        if (!pizzaScroll) {
            if (numCuarto > 1) {
                pizzaScroll = true;
                numCuarto--;
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
    var pizza = '#tblPizza' + numCuarto;
    var scrollPosition = ($(pizza).position().left) - ($(pizzas).position().left);
    if (direccion == 'anterior') {
        $('.pizzaArea').animate({ scrollLeft: scrollPosition }, '500', 'swing', function () {
            pizzaScroll = false;
        });
    } else {
        $('.pizzaArea').animate({ scrollLeft: scrollPosition }, '500', 'swing', function () {
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

function desplegarIngredientes() {
    //obtenemos el array de ingredientes
    var items = $('#pizza' + numCuarto + ' .ingrediente').toArray();
    /*//Ordenamos los ingredientes por el z-index
    items = items.sort(function(a, b) {
        return(Number($(a).zIndex()) - Number($(b).zIndex()));
    });*/
    items.forEach(function (aItem) {
        var classList = aItem.className.split(/\s+/);
        $('#detallesRow').append('<td class="detallesItemTd"><div class="detallesItem ' + classList[1] + 'Icon" id="' + aItem.id + 'Icon"></div><td>');
        $('#' + aItem.id + 'Icon').fadeIn();

    });
}

function recalcularIngredientes() {
    $('#resumenIngredientes').html('<tr><th>Descripci&oacute;n</th><th>Precio</th></tr></tr>');//reiniciamos la tabla
    var precioTotal = 0;

    $('#resumenIngredientes').append('<tr id="resumenPizza"></tr>');
    var precioUnit = $('#addPizza').attr('precio');
    var totalIngrediente = ($('.pizza').length) * precioUnit;
    precioTotal = precioTotal + totalIngrediente;
    var cuartos = contarCuartos('pizza');
    $('#resumenPizza').html('<td>' + cuartos + ' Pizza</td><td>' + totalIngrediente + '</td>');

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
            cuartos = count + '/4 metro';
        } else {
            cuartos = '1/2 metro';
        }
    } else if (count % 4 == 0) {
        cuartos = (count / 4);
        if (cuartos == 1) {
            cuartos += ' metro';
        } else {
            cuartos += ' metros';
        }
    } else {
        cuartos = parseInt((count / 4), 0);
        if (cuartos == 1) {
            var metros = ' metro';
        } else {
            var metros = ' metros';
        }
        cuartos += ' ' + (count % 4) + '/4 ' + metros;
    }

    return cuartos;
}