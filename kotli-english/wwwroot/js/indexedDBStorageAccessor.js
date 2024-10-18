const CURRENT_VERSION = 1;
const DATABASE_NAME = "kotli-english";
export function initialize(collectionName) {
    const kotliEnglishIndexedDB = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    kotliEnglishIndexedDB.onupgradeneeded = function () {
        const db = kotliEnglishIndexedDB.result;
        db.createObjectStore(collectionName);
    }
}

export function set(collectionName, key, value) {
    const kotliEnglishIndexedDB = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    kotliEnglishIndexedDB.onsuccess = function () {
        const transaction = kotliEnglishIndexedDB.result.transaction(collectionName, "readwrite");
        const collection = transaction.objectStore(collectionName);
        collection.put(value, key);
    }
}

export async function get(collectionName, key) {
    const request = new Promise((resolve) => {
        const kotliEnglishIndexedDB = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        kotliEnglishIndexedDB.onsuccess = function () {
            const transaction = kotliEnglishIndexedDB.result.transaction(collectionName, "readonly");
            const collection = transaction.objectStore(collectionName);
            const result = collection.get(key);

            result.onsuccess = function (e) {
                resolve(result.result);
            }
        }
    });

    const result = await request;
    return result;
}