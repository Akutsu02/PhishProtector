// JavaScript source code
browser.browserAction.onClicked.addListener(() => {
    // Le code ici sera ex�cut� lorsque l'utilisateur cliquera sur l'ic�ne de l'extension.
    console.log("L'ic�ne de l'extension a �t� cliqu�e !");


});

browser.webNavigation.onBeforeNavigate.addListener((details) => {
  // L'utilisateur est en train de naviguer vers une nouvelle page
  console.log("Changement de site :", details.url);
  
      // R�cup�re l'onglet actif
    browser.tabs.query({ active: true, currentWindow: true })
        .then((tabs) => {
            const tab = tabs[0];
            console.log(tab.url);
			const baseUrl = tab.url;
			console.log("Base de l'URL :", baseUrl);
			
			
	 	
			// Capturer la capture d'�cran de l'onglet actif
			browser.tabs.captureTab(tab.id)
				.then((dataUrl) => {
					sendToAntiPhishingAPI(baseUrl, dataUrl);
				})
				.catch((error) => {
					console.error("Impossible de capturer la capture d'�cran de l'onglet :", error);
				});
			
			
			
			
			    
					  
     
        })
        .catch((error) => {
            console.error("Impossible de r�cup�rer l'onglet actif :", error);
		});


	async function sendToAntiPhishingAPI(url, imageData) {
		try {
			console.log("sendToAntiPhishingAPI");
			const apiURL = 'http://localhost:5001/api/analyze';

			// Convertir l'imageData en Blob
			const imageBlob = new Blob([new Uint8Array(imageData)], { type: 'image/png' });

			// Cr�er un objet FormData pour envoyer l'URL et l'image
			const formData = new FormData();
			formData.append('url', url);
			//formData.append('screenBytes', imageBlob);
			formData.append('screenBytes', imageData);

			// Envoyer la requ�te � l'API
			const response = await fetch(apiURL, {
				method: 'POST',
				body: formData,
			});

			// V�rifier si la requ�te a r�ussi
			if (!response.ok) {
				throw new Error(`Erreur lors de l'appel � l'API : ${response.statusText}`);
			}

			// Traiter la r�ponse de l'API
			const result = await response.text();
			console.log('R�sultat de l\'API:', result);
		} catch (error) {
			console.error('Erreur lors de l\'envoi des donn�es � l\'API Anti-Phishing :', error);
		}
	}
});