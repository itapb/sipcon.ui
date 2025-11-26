/* ==========================================================
   Chatbot CONI - JS actualizado con menú lateral de dos niveles
   ========================================================== */

document.addEventListener("DOMContentLoaded", () => {
  document.body.classList.add('chatbot-active');
  const chatbotButton = document.querySelector(".chatbot-button");
  const chatbotWindow = document.querySelector(".chatbot-window");
  const closeButton = document.querySelector(".chatbot-close");
  const chatbotBody = document.querySelector(".chatbot-body");
  const sendButton = document.querySelector(".send-button") || document.querySelector(".chatbot-input button");
  const inputField = document.querySelector(".chatbot-input input");

  // Crear overlay y botón de menú
  const overlay = document.createElement("div");
  overlay.classList.add("chatbot-overlay");
  document.body.appendChild(overlay);

  const menuButton = document.createElement("button");
  menuButton.classList.add("menu-button");
  menuButton.innerHTML = "MENU";
  document.querySelector(".chatbot-input").prepend(menuButton);

  const menuContainer = document.createElement("div");
  menuContainer.classList.add("circular-menu");
  document.querySelector(".chatbot-window").appendChild(menuContainer);

  let currentFlow = {};
  let menuNivel = 'principal'; 
  let moduloActual = null;
  let submoduloActual = null; // ← NUEVA: para rastrear el submódulo actual 
  let moduloSeleccionadoMenu = null;
  let pasoAPasoActivo = false; // ← NUEVA: para controlar si hay un paso a paso en curso

  // --- Burbuja del mensaje para el logo ---
  const bubble = document.getElementById('coni-login-bubble');
  
  // Función para mostrar la burbuja
  function mostrarBurbuja() {
    if (bubble) {
      bubble.style.display = 'block';
      setTimeout(() => {
        bubble.style.opacity = '1';
      }, 10);
    }
  }

  // Función para ocultar la burbuja
  function ocultarBurbuja() {
    if (bubble) {
      bubble.style.opacity = '0';
      setTimeout(() => {
        bubble.style.display = 'none';
      }, 300);
    }
  }

/* --- Descargar manual PDF específico del módulo o submódulo --- */
function downloadManualPDF() {
  // Mapeo de módulos y submódulos a sus PDFs - USANDO LOS ID CORRECTOS
  const basePath = 'js/chat_bot/manuales/';
  const pdfMap = {
    // Módulos principales
    'contacto': `${basePath}manual-contactos.pdf`,
    
    // Submódulos específicos (usando los ID exactos del JSON)
    'vehiculos-sub': `${basePath}manual-Vehiculos.pdf`,
    'modelos-sub': `${basePath}manual-Modelos.pdf`,
    'mano-obra-sub': `${basePath}manual-Mano de Obra.pdf`,
    'gestion-polizas': `${basePath}manual-Polizas.pdf`,
    'tipos-polizas': `${basePath}manual-Tipos de polizas.pdf`,
    'repuestos-sub': `${basePath}manual-Repuestos.pdf`,
    'inventario-sub': `${basePath}manual-Inventario.pdf`,
    'almacen-sub': `${basePath}manual-Almacen.pdf`,
    'Zonas-sub': `${basePath}manual-Zonas.pdf`,
    'ubicaciones-sub': `${basePath}manual-Ubicaciones.pdf`,
    'recepcion-sub': `${basePath}manual-Recepcion-Inventario.pdf`,
    'traslado-sub': `${basePath}manual-Traslado.pdf`,
    'recoleccion-sub': `${basePath}manual-Recoleccion.pdf`,
    'Ajustes-sub': `${basePath}manual-Ajuste.pdf`,
    'BackOrders-sub': `${basePath}manual-BackOrders.pdf`,
    'Control de facturacion-sub': `${basePath}manual-Control Facturacion.pdf`,
    'asistencia-tecnica-sub': `${basePath}manual-Asistencia Tecnica.pdf`,
    'licencias-sub': `${basePath}manual-Licencias.pdf`,
    'mantenimiento-sub': `${basePath}manual-Mantenimiento.pdf`,
    'reporte-falla-sub': `${basePath}manual-Reporte de Falla.pdf`,
    'gestion-pedidos': `${basePath}manual-Pedidos.pdf`,
    'recepcion-pedidos': `${basePath}manual-Recepcion-Pedidos.pdf`
  };
  
  // PRIORIDAD 1: Si hay un submódulo actual, usar su manual
  let pdfUrl;
  let fileName;
  
  if (submoduloActual && submoduloActual.id && pdfMap[submoduloActual.id]) {
    pdfUrl = pdfMap[submoduloActual.id];
    fileName = `manual-${submoduloActual.id}.pdf`;
    console.log(`📥 Descargando manual del SUBMÓDULO: ${submoduloActual.label} (ID: ${submoduloActual.id})`);
  }
  // PRIORIDAD 2: Si hay módulo actual pero no submódulo, usar manual del módulo
  else if (moduloActual && moduloActual.id && pdfMap[moduloActual.id]) {
    pdfUrl = pdfMap[moduloActual.id];
    fileName = `manual-${moduloActual.id}.pdf`;
    console.log(`📥 Descargando manual del MÓDULO: ${moduloActual.label} (ID: ${moduloActual.id})`);
  }
  // PRIORIDAD 3: Manual por defecto
  else {
    pdfUrl = 'js/chat_bot/manuales/manual-general.pdf';
    fileName = 'manual-general.pdf';
    console.log('📥 Descargando manual general');
  }
  
  // Crear enlace temporal para descargar
  const link = document.createElement('a');
  link.style.display = 'none';
  link.href = pdfUrl;
  link.download = fileName;
  
  document.body.appendChild(link);
  link.click();
  document.body.removeChild(link);
  
  // Mostrar mensaje de confirmación
  const manualName = submoduloActual ? submoduloActual.label : (moduloActual ? moduloActual.label : 'General');
  //showMessage(`📄 Descargando manual de: ${manualName}`, "coni");
}

/* --- Buscar módulo padre y submódulo actual --- */
function findParentModuleAndSetSubmodule(currentOption) {
  // Resetear submódulo actual
  submoduloActual = null;
  
  // Buscar en todos los módulos principales
  for (let modulo of currentFlow.modulos_principales) {
    if (modulo.submenu) {
      // Buscar directamente en el submenu del módulo
      const foundInSubmenu = modulo.submenu.find(item => item.id === currentOption.id);
      if (foundInSubmenu) {
        moduloActual = modulo;
        // Guardar la información del SUBMÓDULO, no de la opción específica
        submoduloActual = {
          id: foundInSubmenu.id,
          label: foundInSubmenu.label // ← Este es el nombre del submódulo (ej: "Zonas")
        };
        return modulo;
      }
      
      // Buscar recursivamente en sub-submenús
      for (let subItem of modulo.submenu) {
        if (subItem.submenu) {
          const foundInSubSubmenu = subItem.submenu.find(item => item.id === currentOption.id);
          if (foundInSubSubmenu) {
            moduloActual = modulo;
            // Guardar la información del SUBMÓDULO PADRE, no de la opción específica
            submoduloActual = {
              id: subItem.id,
              label: subItem.label // ← Este es el nombre del submódulo padre (ej: "Zonas")
            };
            return modulo;
          }
        }
      }
    }
  }
  
  console.log("❌ No se encontró módulo padre para:", currentOption.label);
  return null;
}

/* --- Manejar opciones (MODIFICADA) --- */
function handleOption(option) {
  document.querySelectorAll(".option-buttons").forEach(el => el.remove());
  showMessage(option.label, "user");

  if (option.action === "submenu") {
    // Actualizar módulo y submódulo
    findParentModuleAndSetSubmodule(option);
    
    showMessage(option.description, "coni");
    showOptions(option.submenu);
    inSubMenu = true;
  } else if (option.action === "back") {
    // Al volver atrás, resetear el submódulo actual
    submoduloActual = null;
    showMainMenu();
    inSubMenu = false;
  } else if (option.action === "mostrar") {
    // ESTABLECER SUBMÓDULO ACTUAL cuando se selecciona un flujo
    findParentModuleAndSetSubmodule(option);
    
    showMessage(option.description, "coni");
    
    if (option.pasos && option.pasos.length > 0) {
      showMessage("Te mostraré cada paso con su imagen correspondiente:", "coni");
      showStepsSequentially(option.pasos, option.images || []);
    }
  } else {
    showMessage("✅ Acción seleccionada: " + option.label, "coni");
  }
}

/* --- Mostrar menú principal (MODIFICADA) --- */
function showMainMenu() {
  moduloActual = null; // Resetear módulo actual
  submoduloActual = null; // ← TAMBIÉN resetear submódulo actual
  showMessage("Estos son los módulos disponibles:", "coni");
  // Mostrar solo los módulos principales
  showOptions(currentFlow.modulos_principales);
}

  // Mostrar burbuja al cargar
  setTimeout(mostrarBurbuja, 100);

  /* --- Abrir/Cerrar chatbot --- */
chatbotButton.addEventListener("click", (e) => {
  e.stopPropagation();
  chatbotWindow.classList.toggle("open");
  if (chatbotWindow.classList.contains("open")) {
    ocultarBurbuja();
    // Detener la animación del logo
    const logo = document.querySelector('.chatbot-button');
    if (logo) {
      logo.style.animation = 'none';
      logo.style.transform = 'translate(0, 0)';
    }
  } else {
    mostrarBurbuja();
    // Reanudar la animación del logo
    const logo = document.querySelector('.chatbot-button');
    if (logo) {
      logo.style.animation = ''; // Restaurar animación por defecto
      logo.style.transform = '';
    }
  }
});

  closeButton.addEventListener("click", () => {
  chatbotWindow.classList.remove("open");
  overlay.classList.remove("show");
  menuButton.classList.remove("open");
  menuContainer.classList.remove("show");
  mostrarBurbuja();
  
  // Restaurar animación del logo 
  const logo = document.querySelector('.chatbot-button');
  if (logo) {
    logo.style.animation = 'float 3s ease-in-out infinite'; 
    logo.style.transform = '';
  }
});

document.addEventListener("click", (e) => {
  if (!chatbotWindow.contains(e.target) && 
      !chatbotButton.contains(e.target) && 
      chatbotWindow.classList.contains("open")) {
    // Cerrar chat
    chatbotWindow.classList.remove("open");
    overlay.classList.remove("show");
    menuButton.classList.remove("open");
    menuContainer.classList.remove("show");
    mostrarBurbuja();
    
    // Restaurar animación del logo
    const logo = document.querySelector('.chatbot-button');
    if (logo) {
      logo.style.animation = '';
      logo.style.transform = '';
    }
  }
});

chatbotWindow.addEventListener("click", (e) => {
  e.stopPropagation();
});


  // Observar cambios en el chatbot por si se cierra de otras formas
  if (chatbotWindow && bubble) {
    const observer = new MutationObserver(function(mutations) {
      mutations.forEach(function(mutation) {
        if (mutation.attributeName === 'class') {
          if (!chatbotWindow.classList.contains('open')) {
            // Chatbot cerrado - mostrar burbuja
            setTimeout(mostrarBurbuja, 300);
          }
        }
      });
    });
    
    observer.observe(chatbotWindow, { attributes: true });
  }

  /* --- Cargar flujos desde JSON --- */
  async function loadFlows() {
    try {
      const response = await fetch("js/chat_bot/flujos.json");
      const data = await response.json();
      currentFlow = data;
      showMessage("👋 ¡Hola! Soy CONI, tu Asistente de SIPCON.<br>¿Necesitas ayuda con algún módulo del sistema?<br>¡Explora el menú de módulos y te explicaré el paso a paso! 👇🏼", "coni");
    } catch (error) {
      console.error("Error cargando flujos:", error);
      showMessage("❌ No se pudieron cargar los módulos. Inténtalo más tarde.", "coni");
    }
  }

  /* --- Mostrar mensajes en el chat --- */
  function showMessage(text, sender) {
    const msg = document.createElement("div");
    msg.classList.add("message", sender);
    const bubble = document.createElement("div");
    bubble.classList.add("bubble", sender);
    bubble.innerHTML = text;
    msg.appendChild(bubble);
    chatbotBody.appendChild(msg);
    chatbotBody.scrollTop = chatbotBody.scrollHeight;
  }

  /* --- Mostrar botones de opciones --- */
  function showOptions(options) {
    // Limpiar botones anteriores
    document.querySelectorAll(".option-buttons").forEach(el => el.remove());
    
    const container = document.createElement("div");
    container.classList.add("option-buttons");
    
    options.forEach(opt => {
      const btn = document.createElement("button");
      btn.textContent = opt.label;
      
      // Prevenir múltiples clics
      let clickHabilitado = true;
      btn.addEventListener("click", () => {
        if (!clickHabilitado) return;
        clickHabilitado = false;
        
        // Deshabilitar visualmente el botón
        btn.style.opacity = "0.6";
        btn.style.cursor = "not-allowed";
        
        // Ejecutar la acción después de un pequeño delay
        setTimeout(() => {
          handleOption(opt);
        }, 100);
      });
      
      container.appendChild(btn);
    });
    
    chatbotBody.appendChild(container);
    chatbotBody.scrollTop = chatbotBody.scrollHeight;
  }

  /* --- Limpiar todo el chat --- */
  function clearChat() {
    // Limpiar todos los mensajes y botones
    chatbotBody.innerHTML = '';
     
    // Mostrar mensaje de confirmación
    showMessage("✅ Chat limpiado. Si deseas conocer otro paso a paso de un módulo, utiliza el menú de módulos. 👇🏻", "coni");
  }

function showStepsSequentially(pasos, images = []) {
  // DESHABILITAR MENÚ Y BOTÓN DE ENVIAR MIENTRAS DURE EL PASO A PASO
  pasoAPasoActivo = true;
  menuButton.style.pointerEvents = 'none';
  menuButton.style.opacity = '0.5';
  sendButton.style.pointerEvents = 'none';
  sendButton.style.opacity = '0.5';
  inputField.disabled = true;
  
  let currentStep = 0;

  function showNextStep() {
    if (currentStep >= pasos.length) {
      // REHABILITAR TODO AL TERMINAR EL PASO A PASO
      pasoAPasoActivo = false;
      menuButton.style.pointerEvents = 'auto';
      menuButton.style.opacity = '1';
      sendButton.style.pointerEvents = 'auto';
      sendButton.style.opacity = '1';
      inputField.disabled = false;
      
      setTimeout(() => {
        showMessage("¡Listo! Has completado todos los pasos. También puedes descargar el manual en la opción 👇🏻", "coni");

        const optionsContainer = document.createElement("div");
        optionsContainer.classList.add("option-buttons");

        // Botón para descargar manual PDF DEL MÓDULO ACTUAL
        const pdfBtn = document.createElement("button");
        pdfBtn.textContent = `📄 Descargar Manual ${submoduloActual?.label || moduloActual?.label || 'General'}`;
        pdfBtn.classList.add("option-btn");

        let pdfHabilitado = true;
        pdfBtn.addEventListener("click", () => {
          if (!pdfHabilitado) return;
          pdfHabilitado = false;
          pdfBtn.style.opacity = "0.6";
          pdfBtn.style.cursor = "not-allowed";
          downloadManualPDF();
        });

        optionsContainer.appendChild(pdfBtn);

        // Mostrar botón de otros flujos si estamos en un submódulo
        if (submoduloActual) {
          const otrosFlujosBtn = document.createElement("button");
          otrosFlujosBtn.innerHTML = `¿Deseas explorar otras funciones disponibles<br> del módulo ${submoduloActual.label}? haz clic 🔄`;
          otrosFlujosBtn.classList.add("option-btn");

          let clickHabilitado = true;
          otrosFlujosBtn.addEventListener("click", () => {
            if (!clickHabilitado) return;
            clickHabilitado = false;

            otrosFlujosBtn.style.opacity = "0.6";
            otrosFlujosBtn.style.cursor = "not-allowed";

            showMessage(`Perfecto, continuemos con los flujos de ${submoduloActual.label}:`, "coni");
            
            // Buscar el submódulo actual completo en la estructura JSON
            const moduloPadre = currentFlow.modulos_principales.find(m => m.id === moduloActual.id);
            if (moduloPadre && moduloPadre.submenu) {
              const submoduloCompleto = moduloPadre.submenu.find(sub => sub.id === submoduloActual.id);
              if (submoduloCompleto) {
                // Si el submódulo tiene flujos (submenu), mostrarlos
                if (submoduloCompleto.submenu) {
                  showOptions(submoduloCompleto.submenu);
                } else {
                  // Si no tiene flujos propios, mostrar los submódulos del módulo padre
                  showOptions(moduloPadre.submenu);
                }
              } else {
                // Fallback: mostrar submódulos del módulo padre
                showOptions(moduloPadre.submenu);
              }
            }
          });

          optionsContainer.appendChild(otrosFlujosBtn);
        }
        // O si no hay submódulo pero hay módulo con submenu
        else if (moduloActual && moduloActual.submenu) {
          const otrosFlujosBtn = document.createElement("button");
          otrosFlujosBtn.innerHTML = `¿Deseas explorar otras funciones disponibles<br> del módulo ${moduloActual.label}? haz clic  🔄`;
          otrosFlujosBtn.classList.add("option-btn");

          let clickHabilitado = true;
          otrosFlujosBtn.addEventListener("click", () => {
            if (!clickHabilitado) return;
            clickHabilitado = false;

            otrosFlujosBtn.style.opacity = "0.6";
            otrosFlujosBtn.style.cursor = "not-allowed";

            showMessage(`Perfecto, continuemos con los flujos de ${moduloActual.label}:`, "coni");
            // Buscar y mostrar los submódulos del módulo actual
            const moduloCompleto = currentFlow.modulos_principales.find(m => m.id === moduloActual.id);
            if (moduloCompleto && moduloCompleto.submenu) {
              showOptions(moduloCompleto.submenu);
            }
          });

          optionsContainer.appendChild(otrosFlujosBtn);
        }

        // Botón de limpiar chat
        const clearBtn = document.createElement("button");
        clearBtn.textContent = "🧹 Desea reiniciar chat? dar clic";
        clearBtn.classList.add("option-btn");

        let clearHabilitado = true;
        clearBtn.addEventListener("click", () => {
          if (!clearHabilitado) return;
          clearHabilitado = false;
          clearBtn.style.opacity = "0.6";
          clearBtn.style.cursor = "not-allowed";
          clearChat();
        });

        optionsContainer.appendChild(clearBtn);
        chatbotBody.appendChild(optionsContainer);
        chatbotBody.scrollTop = chatbotBody.scrollHeight;
      }, 500);
      return;
    }

    const paso = pasos[currentStep];
    const imagen = images[currentStep] || null;
    const numeroPaso = currentStep + 1;

    showMessage(`<strong>Paso ${numeroPaso}:</strong> ${paso}`, "coni");

    if (imagen) {
      setTimeout(() => {
        showImageMessage(imagen, numeroPaso, paso);
      }, 1000);
    }

    currentStep++;
    const delay = imagen ? 3000 : 2000;
    setTimeout(showNextStep, delay);
  }

  setTimeout(showNextStep, 1000);
}

  /* --- Mostrar imagen en mensaje separado con funcionalidad de zoom --- */
  function showImageMessage(imageSrc, stepNumber, descripcionPaso) {
    const imageMessage = document.createElement("div");
    imageMessage.classList.add("message", "coni", "image-message");
    
    const bubble = document.createElement("div");
    bubble.classList.add("bubble", "coni", "image-bubble");
    
    const imageContainer = document.createElement("div");
    imageContainer.classList.add("image-container");
    
    const img = document.createElement("img");
    img.src = imageSrc;
    img.alt = `Paso ${stepNumber}`;
    img.classList.add("step-image");
    
    // Agregar tooltip para hacer clic
    const clickHint = document.createElement("div");
    clickHint.classList.add("click-hint");
    clickHint.textContent = "🔍 Haz clic en la imagen para ampliar";
    
    imageContainer.appendChild(img);
    imageContainer.appendChild(clickHint);
    bubble.appendChild(imageContainer);
    imageMessage.appendChild(bubble);
    chatbotBody.appendChild(imageMessage);
    
    chatbotBody.scrollTop = chatbotBody.scrollHeight;
    
    // Agregar funcionalidad de lightbox al hacer clic
    img.addEventListener("click", () => {
      openLightbox(imageSrc, stepNumber, descripcionPaso);
    });
  }

  /* --- Lightbox para ampliar imágenes --- */
  function openLightbox(imageSrc, stepNumber, descripcionPaso) {
    // Crear overlay del lightbox
    const lightbox = document.createElement("div");
    lightbox.classList.add("lightbox");
    lightbox.innerHTML = `
      <div class="lightbox-content">
        <button class="lightbox-close">&times;</button>
        <div class="lightbox-header">
          <h3>Paso ${stepNumber}</h3>
        </div>
        <div class="lightbox-image-container">
          <img src="${imageSrc}" alt="Paso ${stepNumber}" class="lightbox-image">
        </div>
        <div class="lightbox-controls">
          <span class="lightbox-counter">${descripcionPaso}</span>
        </div>
      </div>
    `;
    
    document.body.appendChild(lightbox);
    
     lightbox.addEventListener("click", (e) => {
    e.stopPropagation(); // ← Esto previene que el clic llegue al documento
    });
    
    // Cerrar lightbox
    const closeBtn = lightbox.querySelector(".lightbox-close");
    closeBtn.addEventListener("click", () => {
      document.body.removeChild(lightbox);
    });
    
    // Cerrar al hacer clic fuera de la imagen
    lightbox.addEventListener("click", (e) => {
      if (e.target === lightbox) {
        document.body.removeChild(lightbox);
      }
    });
    
    // Cerrar con tecla ESC
    document.addEventListener("keydown", function closeOnEscape(e) {
      if (e.key === "Escape") {
        document.body.removeChild(lightbox);
        document.removeEventListener("keydown", closeOnEscape);
      }
    });
  }

  /* --- Cargar menú circular de dos niveles --- */
  function loadCircularMenu(nivel = 'principal', moduloId = null) {
    menuContainer.innerHTML = "";
    
    if (nivel === 'principal') {
      // Mostrar módulos principales
      menuNivel = 'principal';
      moduloSeleccionadoMenu = null;
      
      currentFlow.modulos_principales.forEach(mod => {
        const item = document.createElement("div");
        item.classList.add("menu-item");
        item.innerHTML = `${mod.icon} <span>${mod.label}</span>`; 
        item.addEventListener("click", () => {
          moduloSeleccionadoMenu = mod;
          loadCircularMenu('submodulos', mod.id);
        });
        menuContainer.appendChild(item);
      });
    } else {
      // Mostrar submódulos del módulo seleccionado
      menuNivel = 'submodulos';
      const modulo = currentFlow.modulos_principales.find(m => m.id === moduloId);
      
      if (!modulo || !modulo.submenu) {
        console.error("Módulo no encontrado o sin submenú:", moduloId);
        return;
      }
      
      // Botón de regreso
      const backItem = document.createElement("div");
      backItem.classList.add("menu-item", "back-item");
      backItem.innerHTML = "⬅️ <span>Volver a Módulos</span>";
      backItem.addEventListener("click", () => {
        loadCircularMenu('principal');
      });
      menuContainer.appendChild(backItem);
      
    // Submódulos
     modulo.submenu.forEach(sub => {
     const item = document.createElement("div");
     item.classList.add("menu-item", "submenu-item");
     item.innerHTML = `<span>${sub.label}</span>`;
     item.addEventListener("click", () => {
     menuButton.click(); // cerrar menú
     showMessage(`📋 ${sub.label}`, "user");
     showMessage(sub.description, "coni");
    
    // ACTUALIZAR SUBMÓDULO ACTUAL CORRECTAMENTE
      submoduloActual = {
      id: sub.id,
      label: sub.label
       };
    
       if (sub.submenu) {
      showOptions(sub.submenu);
       } else if (sub.action === "mostrar") {
      // Si es una acción directa, manejarla
      handleOption(sub);
       }
      });
     menuContainer.appendChild(item);
     });
    }
  }

/* --- Botón de menú circular (parte inferior izquierda) --- */
 menuButton.addEventListener("click", () => {
  // NO PERMITIR ABRIR MENÚ MIENTRAS HAY PASO A PASO ACTIVO
  if (pasoAPasoActivo) {
    showMessage("⏳ Por favor espera a que termine el paso a paso actual...", "coni");
    return;
  }
  
  const isOpen = menuButton.classList.toggle("open");
  menuButton.innerHTML = isOpen ? "✕" : "MENU";
  overlay.classList.toggle("show", isOpen);
  menuContainer.classList.toggle("show", isOpen);
  
  // Si se abre el menú, SIEMPRE cargar el menú principal
  if (isOpen) {
    menuNivel = 'principal';
    moduloSeleccionadoMenu = null;
    loadCircularMenu('principal');
  }
});

  overlay.addEventListener("click", () => {
    menuButton.classList.remove("open");
    menuButton.innerHTML = "MENU";
    overlay.classList.remove("show");
    menuContainer.classList.remove("show");
  });

  /* --- Envío manual (texto libre) --- */
  sendButton.addEventListener("click", () => {
    const text = inputField.value.trim();
    if (text) {
      showMessage(text, "user");
      showMessage("🤖 Aún no entiendo mensajes personalizados, elige una opción del menú. 👇🏻", "coni");
      inputField.value = "";
    }
  });

  /* --- Inicialización --- */
  loadFlows().then(() => {
    loadCircularMenu('principal');
  });
});