window.dragDrop = {
    init: function (dotnetRef, containerId) {
        const container = document.getElementById(containerId);
        if (!container) return;

        let dragFromIndex = -1;
        let placeholder = null;

        container.addEventListener('dragstart', e => {
            const row = e.target.closest('.option-row');
            if (!row) return;
            dragFromIndex = parseInt(row.dataset.index);
            row.classList.add('dragging');
            e.dataTransfer.effectAllowed = 'move';
        });

        container.addEventListener('dragover', e => {
            e.preventDefault();
            e.dataTransfer.dropEffect = 'move';
            const row = e.target.closest('.option-row');
            if (!row) return;
            container.querySelectorAll('.option-row').forEach(r => r.classList.remove('drag-over'));
            row.classList.add('drag-over');
        });

        container.addEventListener('dragleave', e => {
            if (!container.contains(e.relatedTarget)) {
                container.querySelectorAll('.option-row').forEach(r => r.classList.remove('drag-over'));
            }
        });

        container.addEventListener('drop', e => {
            e.preventDefault();
            const row = e.target.closest('.option-row');
            container.querySelectorAll('.option-row').forEach(r => {
                r.classList.remove('drag-over');
                r.classList.remove('dragging');
            });
            if (!row) return;
            const targetIndex = parseInt(row.dataset.index);
            if (dragFromIndex >= 0 && dragFromIndex !== targetIndex) {
                dotnetRef.invokeMethodAsync('OnDropJS', dragFromIndex, targetIndex);
            }
            dragFromIndex = -1;
        });

        container.addEventListener('dragend', e => {
            container.querySelectorAll('.option-row').forEach(r => {
                r.classList.remove('drag-over');
                r.classList.remove('dragging');
            });
            dragFromIndex = -1;
        });
    }
};
