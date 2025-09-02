window.getWindowHeight = () => { return window.innerHeight; };

function downloadFile(url, fileName) {
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function timerInactivo(dotnetHelper) {
    var timer;
    document.onmousemove = resetTimer;
    document.onkeyup = resetTimer;
    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout, 500000); // 5 minutos         
    }

    function logout() {
        dotnetHelper.invokeMethodAsync('logout') ;
    }

}
