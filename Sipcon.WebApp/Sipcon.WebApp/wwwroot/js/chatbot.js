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
  let inSubMenu = false;
  let moduloActual = null;
  let menuNivel = 'principal'; // 'principal' o 'submodulos'
  let moduloSeleccionadoMenu = null;

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
        const observer = new MutationObserver(function (mutations) {
            mutations.forEach(function (mutation) {
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

  /* --- Descargar manual PDF específico del módulo --- */
  function downloadManualPDF() {
    // Mapeo de módulos a sus PDFs
    const basePath = 'js/chat_bot/manuales/';
    const pdfMap = {
      'contacto': `${basePath}manual-contactos.pdf`,
      'vehiculo': `${basePath}manual-vehiculos.pdf`,
      'polizas': `${basePath}manual-polizas.pdf`,
      'inventario': `${basePath}manual-inventario.pdf`,
      'servicios': `${basePath}manual-servicios.pdf`,
      'pedidos': `${basePath}manual-pedidos.pdf`,
      'gestion-usuarios': `${basePath}manual-gestion-usuarios.pdf`
    };
    
    // Obtener el PDF según el módulo actual
    let pdfUrl;
    if (moduloActual && moduloActual.id && pdfMap[moduloActual.id]) {
      pdfUrl = pdfMap[moduloActual.id];
    } else {
      // PDF por defecto si no hay módulo específico
        pdfUrl = 'js/chat_bot/manuales/manual-general.pdf';
    }
    
    // Crear enlace temporal para descargar
    const link = document.createElement('a');
    link.style.display = 'none';
    link.href = pdfUrl;
    
    // Nombre del archivo basado en el módulo
    const fileName = moduloActual ? `manual-${moduloActual.id}.pdf` : 'manual-general.pdf';
    link.download = fileName;
    
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }

  /* --- Buscar módulo padre para una opción --- */
  function findParentModule(currentOption) {
    // Buscar en todos los módulos principales
    for (let modulo of currentFlow.modulos_principales) {
      if (modulo.submenu) {
        // Buscar en el submenu del módulo
        const found = modulo.submenu.find(item => item.id === currentOption.id);
        if (found) {
          return modulo;
        }
        
        // Buscar recursivamente en sub-submenús
        for (let subItem of modulo.submenu) {
          if (subItem.submenu) {
            const foundInSub = subItem.submenu.find(item => item.id === currentOption.id);
            if (foundInSub) {
              return modulo;
            }
          }
        }
      }
    }
    console.log("❌ No se encontró módulo padre para:", currentOption.label);
    return null;
  }

  /* --- Manejar opciones --- */
  function handleOption(option) {
    document.querySelectorAll(".option-buttons").forEach(el => el.remove());
    showMessage(option.label, "user");

    if (option.action === "submenu") {
      // SIEMPRE buscar el módulo padre para opciones de submenu
      const parentModule = findParentModule(option);
      if (parentModule) {
        moduloActual = parentModule;
      }
      
      showMessage(option.description, "coni");
      showOptions(option.submenu);
      inSubMenu = true;
    } else if (option.action === "back") {
      showMainMenu();
      inSubMenu = false;
    } else if (option.action === "mostrar") {
      // SIEMPRE buscar el módulo padre para opciones de mostrar
      const parentModule = findParentModule(option);
      if (parentModule) {
        moduloActual = parentModule;
      }
      
      showMessage(option.description, "coni");
      
      if (option.pasos && option.pasos.length > 0) {
        showMessage("Te mostraré cada paso con su imagen correspondiente:", "coni");
        showStepsSequentially(option.pasos, option.images || []);
      }
    } else {
      showMessage("✅ Acción seleccionada: " + option.label, "coni");
    }
  }

  function showStepsSequentially(pasos, images = []) {
    let currentStep = 0;

    function showNextStep() {
      if (currentStep >= pasos.length) {
        setTimeout(() => {
          showMessage("¡Listo! Has completado todos los pasos. También puedes descargar el manual en la opción 👇🏻", "coni");

          const optionsContainer = document.createElement("div");
          optionsContainer.classList.add("option-buttons");

          // Botón para descargar manual PDF DEL MÓDULO ACTUAL
          const pdfBtn = document.createElement("button");
          pdfBtn.textContent = `📄 Descargar Manual ${moduloActual?.label || 'General'}`;
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

          // SOLO mostrar botón de otros flujos si hay un módulo actual con submenu
          if (moduloActual && moduloActual.submenu) {
            const otrosFlujosBtn = document.createElement("button");
            otrosFlujosBtn.innerHTML = `¿Deseas conocer otro paso a paso <br>del módulo ${moduloActual.label}? 🔄`;
            otrosFlujosBtn.classList.add("option-btn");

            let clickHabilitado = true;
            otrosFlujosBtn.addEventListener("click", () => {
              if (!clickHabilitado) return;
              clickHabilitado = false;

              otrosFlujosBtn.style.opacity = "0.6";
              otrosFlujosBtn.style.cursor = "not-allowed";

              showMessage(`Perfecto, continuemos con los flujos de ${moduloActual.label}:`, "coni");
              // Buscar y mostrar los flujos del módulo actual
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
        }, 1000);
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

  /* --- Mostrar menú principal dentro del chat --- */
  function showMainMenu() {
    moduloActual = null; // Resetear módulo actual
    showMessage("Estos son los módulos disponibles:", "coni");
    // Mostrar solo los módulos principales
    showOptions(currentFlow.modulos_principales);
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
    const isOpen = menuButton.classList.toggle("open");
    menuButton.innerHTML = isOpen ? "✕" : "MENU";
    overlay.classList.toggle("show", isOpen);
    menuContainer.classList.toggle("show", isOpen);
    
    // Si se abre el menú, cargar el nivel correspondiente
    if (isOpen) {
      if (menuNivel === 'principal') {
        loadCircularMenu('principal');
      } else if (moduloSeleccionadoMenu) {
        loadCircularMenu('submodulos', moduloSeleccionadoMenu.id);
      }
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