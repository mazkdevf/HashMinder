const { app, BrowserWindow } = require('electron');
const path = require('path');

var production = true;

process.on('unhandledRejection', error => {
    console.log('unhandledRejection', error);
});

function createWindow() {
    var mainWindow = new BrowserWindow({
        width: 800,
        height: 600,
        autoHideMenuBar: true,
        webPreferences: {
            devTools: (production ? false : true),
            nodeIntegration: true,
            contextIsolation: false,
            enableRemoteModule: true,
        }
    });

    mainWindow.loadFile('index.html').catch(err => {});

    (production ? null : mainWindow.webContents.openDevTools())
}

app.whenReady().then(() => {
    createWindow()

    app.on('activate', () => {
        if (BrowserWindow.getAllWindows().length === 0) createWindow()
    })
})

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit()
})