    async function insert(type) {
    const processingText = document.getElementById('processingStatus');
    processingText.innerText = `Processing ${type}...`;    

    try {   
       
        const startTime = new Date().getTime();
        const res = await fetch(`/api/deposit/insert/${type}`, { method: 'POST' });
        const elapsed = ((new Date().getTime() - startTime) / 1000).toFixed(2);

        if (res.ok)
        {
            const data = await res.json();
            console.log(data);
            document.getElementById('total').innerText = data.total;
            appendLog(`Inserted ${type}`);        

            processingText.innerText = `${type} processed in ${elapsed} seconds`;            
        }
        else {
            const err = await res.text();
            console.error('Error:', err);
            if (processingText) {
                processingText.innerText = `Error processing ${type}`;
            }
        }
    } catch (error) {
        console.error('Fetch error:', error);
        if (processingText) {
            processingText.innerText = `Error processing ${type}`;
        }
    } 
}

async function printVoucher() {
    const res = await fetch(`/api/deposit/voucher`, { method: 'POST' });
    if (res.ok) {
        const voucher = await res.json();
        appendLog(`Voucher printed: ${voucher.totalAmount} NOK`);

        const totalElement = document.getElementById('total');
        if (totalElement) {
            totalElement.innerText = `0 NOK`;
        }
    }
    else {
        const err = await res.text();
        console.error('Error:', err);
    }
}

function appendLog(message) {
    const logs = document.getElementById('logs');
    const li = document.createElement('li');
    li.className = 'list-group-item';
    li.textContent = `${new Date().toLocaleTimeString()} - ${message}`;
    logs.prepend(li);
}

document.addEventListener("DOMContentLoaded", () => {
    const btnInsertCan = document.getElementById('btnInsertCan');
    if (btnInsertCan) {
        btnInsertCan.addEventListener('click', (e) => {
            e.preventDefault();        
            insert('Can');      
        });
    }

    const btnInsertBottle = document.getElementById('btnInsertBottle');
    if (btnInsertBottle) {
        btnInsertBottle.addEventListener('click', (e) => {
            e.preventDefault();
            insert('Bottle')
        });
    }

    const btnPrint = document.getElementById('btnPrint');
    if (btnPrint) {
        btnPrint.addEventListener('click', (e) => {
            e.preventDefault();
            printVoucher();
        });
    }

    //console.log('Page loaded, event listeners attached.');

    const logsEl = document.getElementById('logs');
    logsEl.innerHTML = '';

    const totalEl = document.getElementById('total');
    totalEl.innerText = 0;

});