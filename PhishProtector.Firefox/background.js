// JavaScript source code
browser.browserAction.onClicked.addListener(() => {
    // Le code ici sera ex�cut� lorsque l'utilisateur cliquera sur l'ic�ne de l'extension.
    console.log("L'ic�ne de l'extension a �t� cliqu�e !");

    // R�cup�re l'onglet actif
    browser.tabs.query({ active: true, currentWindow: true })
        .then((tabs) => {
            const tab = tabs[0];
            console.log(tab.url);
			
			    // Capturer la capture d'�cran de l'onglet actif
					browser.tabs.captureTab(tab.id)
					  .then((dataUrl) => {
						console.log("Capture d'�cran de l'onglet :", dataUrl);
					  })
					  .catch((error) => {
						console.error("Impossible de capturer la capture d'�cran de l'onglet :", error);
					  });
     
        })
        .catch((error) => {
            console.error("Impossible de r�cup�rer l'onglet actif :", error);
        });
});