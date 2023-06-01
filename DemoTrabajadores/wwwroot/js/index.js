function getProvincias(id) {
    let formprovincia = document.getElementById("formprovincia");
    let formdistrito = document.getElementById("formdistrito");
    if (id == 0) {
        formprovincia.disabled = true
        formdistrito.disabled = true
        formprovincia.options.length = 0;
        formdistrito.options.length = 0;
        var options = formprovincia.options;
        formprovincia[options.length] = new Option("Seleccione una Provincia", 0);
        var options = formdistrito.options;
        formdistrito[options.length] = new Option("Seleccione un Distrito", 0);
    } else {
        formprovincia.disabled = false
        formprovincia.options.length = 1;
        fetch(`/Ubigeo/Provincia?idDepartamento=${id}`)
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(data => {
                data.forEach(e => {
                    var options = formprovincia.options;
                    options[options.length] = new Option(e.nombreProvincia, e.idProvincia);
                })
            })
    }
}
function getDistritos(id) {
    let formdistrito = document.getElementById("formdistrito");
    if (id == 0) {
        formdistrito.disabled = true
        formdistrito.options.length = 0;
        var options = formdistrito.options;
        formdistrito[options.length] = new Option("Seleccione un Distrito", 0);
    } else {
        formdistrito.disabled = false
        formdistrito.options.length = 1;
        fetch(`/Ubigeo/Distrito?idProvincia=${id}`)
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(data => {
                data.forEach(e => {
                    var options = formdistrito.options;
                    options[options.length] = new Option(e.nombreDistrito, e.idDistrito);
                })
            })
    }
}


function eliminar(id) {
    console.log(id)
    console.log("asdasd")
    swal({
        title: "¿Estás seguro?",
        text: "Una vez eliminado no podras recuperar la información",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                fetch(`/Home/Eliminar?idTrabajador=${id}`, {
                    method: "DELETE"
                })
                    .then(response => {
                        return response.ok ? response.json() : Promise.reject(response)
                    })
                    .then(responseJson => {
                        console.log(responseJson)
                        if (responseJson) {

                            // sweetalert
                            swal("Se ha eliminado correctamente el registro", {
                                icon: "success",
                            }).then((aceptar) => {
                                if(aceptar) window.location = window.location ///////////////// cambiar metodo
                            })

                            
                        } else {
                            swal("Lo sentimos", "error")
                        }
                    })
                    .catch(responseJson => {
                        console.log("que paso")
                    })
            }
        });
}
function guardar() {
    let tipoDocumento = document.getElementById("tipoDocumento")
    var sexo = document.getElementsByName('sexo');
    for (i = 0; i < sexo.length; i++) {
        if (sexo[i].checked)
            var genero = sexo[i].value;
    }

    let modelo = {
        TipoDocumento: tipoDocumento.options[tipoDocumento.selectedIndex].text,
        NroDocumento: document.getElementById("nroDocumento").value.trim(),
        Nombres: document.getElementById("inputNombre").value.trim(),
        Sexo: genero,
        IdDistrito: document.getElementById("formdistrito").value
    }

    if (modelo.NroDocumento.length == 0 || modelo.Nombres.length == 0 || modelo.IdDistrito == '0') {
        toastr.warning("Complete todos los campos")
    } else {
        fetch("/Home/Guardar", {
            method: "POST",
            headers: { "Content-Type": "application/json;charset=utf-8" },
            body: JSON.stringify(modelo)
        })
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {
                swal("Listo!", "Los cambios fueron guardados", "success").then((aceptar) => {
                    if (aceptar) window.location = window.location ///////////////// cambiar metodo
                })
            })

    }

}

var modificar = 0
function editar(id) {
    modificar = id
    await fetch(`/Home/Obtener?idTrabajador=${id}`)
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response)
        })
        .then(trabajador => {
            console.log(trabajador)
            document.getElementById("inputNombre1").value = trabajador.nombres
            if (trabajador.tipoDocumento === "DNI") {
                document.getElementById('tipoDocumento1').value = 1
            } else {
                document.getElementById('tipoDocumento1').value = 2
            }
            document.getElementById("nroDocumento1").value = trabajador.nroDocumento
            if (trabajador.sexo == "M") {
                document.getElementById('rbMasculino1').checked = true
            } else {
                document.getElementById('rbFemenino1').checked = true
            }

            var departamento = document.getElementById('formdepartamento1');
            for (var i = 0; i < departamento.options.length; i++) {
                if (departamento.options[i].text === trabajador.departamento) {
                    departamento.selectedIndex = i;
                    break;
                }
            }
        })

    var provincia = document.getElementById('formprovincia1');

    
    provincia.disabled = false

    fetch(`/Ubigeo/Provincia?idDepartamento=${departamento.value}`)
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response)
        })
        .then(data => {
            data.forEach(e => {
                var options = provincia.options;
                options[options.length] = new Option(e.nombreProvincia, e.idProvincia);
            })

            for (var i = 0; i < provincia.options.length + 1; i++) {

                if (provincia.options[i].text === trabajador.provincia) {
                    provincia.selectedIndex = i;
                    break;
                }
            }
            var distrito = document.getElementById('formdistrito1');
            distrito.disabled = false

            fetch(`/Ubigeo/Distrito?idProvincia=${provincia.value}`)
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(data => {
                    data.forEach(e => {
                        var options = distrito.options;
                        options[options.length] = new Option(e.nombreDistrito, e.idDistrito);
                    })
                    console.log("asdasdasdasdasdsa")
                    for (var i = 0; i < distrito.options.length; i++) {
                        if (distrito.options[i].text === trabajador.distrito) {
                            distrito.selectedIndex = i;
                            break;
                        }
                    }
                })
        })
}


function guardarEditado() {
    let tipoDocumento = document.getElementById("tipoDocumento1")
    var sexo = document.getElementsByName('sexo1');
    for (i = 0; i < sexo.length; i++) {
        if (sexo[i].checked)
            var genero = sexo[i].value;
    }

    let modelo = {
        TipoDocumento: tipoDocumento.options[tipoDocumento.selectedIndex].text,
        NroDocumento: document.getElementById("nroDocumento1").value.trim(),
        Nombres: document.getElementById("inputNombre1").value.trim(),
        Sexo: genero,
        IdDistrito: document.getElementById("formdistrito1").value
    }

    if (modelo.NroDocumento.length == 0 || modelo.Nombres.length == 0 || modelo.IdDistrito == '0') {
        toastr.warning("Complete todos los campos")
    } else {
        modelo.IdTrabajador = modificar
        console.log(modelo)
            fetch("/Home/Editar", {
                method: "PUT",
                headers: { "Content-Type": "application/json;charset=utf-8" },
                body: JSON.stringify(modelo)
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {
                    swal("Listo!", "Los cambios fueron guardados", "success").then((aceptar) => {
                        if (aceptar) window.location = window.location ///////////////// cambiar metodo
                    })
                })
        }

}

function getProvincias1(id) {
    console.log("asdasdas")
    let formprovincia = document.getElementById("formprovincia1");
    let formdistrito = document.getElementById("formdistrito1");
    if (id == 0) {
        formprovincia.disabled = true
        formprovincia.options.length = 0;
        var options = formprovincia.options;
        formprovincia[options.length] = new Option("Seleccione una Provincia", 0);

    } else {
        formprovincia.disabled = false
        formprovincia.options.length = 1;
        fetch(`/Ubigeo/Provincia?idDepartamento=${id}`)
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(data => {
                data.forEach(e => {
                    var options = formprovincia.options;
                    options[options.length] = new Option(e.nombreProvincia, e.idProvincia);
                })
            })

    }
    formdistrito.disabled = true
    formdistrito.options.length = 0;
    var options = formdistrito.options;
    formdistrito[options.length] = new Option("Seleccione un Distrito", 0);
}
function getDistritos1(id) {
    let formdistrito = document.getElementById("formdistrito1");
    if (id == 0) {
        formdistrito.disabled = true
        formdistrito.options.length = 0;
        var options = formdistrito.options;
        formdistrito[options.length] = new Option("Seleccione un Distrito", 0);
    } else {
        formdistrito.disabled = false
        formdistrito.options.length = 1;
        fetch(`/Ubigeo/Distrito?idProvincia=${id}`)
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(data => {
                data.forEach(e => {
                    var options = formdistrito.options;
                    options[options.length] = new Option(e.nombreDistrito, e.idDistrito);
                })
            })
    }
}