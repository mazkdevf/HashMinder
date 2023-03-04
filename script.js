function preventDefaults(e) {
    e.preventDefault();
    e.stopPropagation();
}

function highlight(e) {
    e.currentTarget.classList.add('highlight');
}

function unhighlight(e) {
    e.currentTarget.classList.remove('highlight');
}

function handleDrop(e) {
    const dt = e.dataTransfer;
    const files = dt.files;

    handleFiles(files);
}

async function handleFiles(files) {
    const file = files[0];
    const extension = file.name.split('.').pop().toLowerCase();

    if (extension === 'exe') {
        const sha256hash = await computeHash(file, 'sha-256');
        const sha384hash = await computeHash(file, 'sha-384');
        /* document.querySelector('#md5-hash').textContent = md5hash; */
        document.querySelector('#sha256-hash').textContent = sha256hash;
        /* document.querySelector('#sha384-hash').textContent = sha384hash; */

        // press button by id : open_hash_modal
        document.getElementById('open_hash_modal').click();
    }
}

async function computeHash(file, algorithm) {
    const hashBuffer = await crypto.subtle.digest(algorithm, await file.arrayBuffer()).catch(err => console.log(err));
    const hashArray = Array.from(new Uint8Array(hashBuffer));
    const hashHex = hashArray.map(b => b.toString(16).padStart(2, "0")).join("");
    return hashHex;
}



const dropZone = document.querySelector('#drop-zone');

['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
    dropZone.addEventListener(eventName, preventDefaults, false);
});

['dragenter', 'dragover'].forEach(eventName => {
    dropZone.addEventListener(eventName, highlight, false);
});

['dragleave', 'drop'].forEach(eventName => {
    dropZone.addEventListener(eventName, unhighlight, false);
});

dropZone.addEventListener('drop', handleDrop, false);