const CURRENT_VERSION = 1;
const DATABASE_NAME = "kotli-english";
export function initialize() {
    const kotliEnglishIndexedDB = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    kotliEnglishIndexedDB.onupgradeneeded = function () {
        const db = kotliEnglishIndexedDB.result;
        db.createObjectStore("flashcard_settings", { keyPath: "id" });
    }
}

export function set(collectionName, value) {
    const kotliEnglishIndexedDB = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    kotliEnglishIndexedDB.onsuccess = function () {
        const transaction = kotliEnglishIndexedDB.result.transaction(collectionName, "readwrite");
        const collection = transaction.objectStore(collectionName);
        collection.put(value);
    }
}

export async function get(collectionName, id) {
    const request = new Promise((resolve) => {
        const kotliEnglishIndexedDB = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        kotliEnglishIndexedDB.onsuccess = function () {
            const transaction = kotliEnglishIndexedDB.result.transaction(collectionName, "readonly");
            const collection = transaction.objectStore(collectionName);
            const result = collection.get(id);

            result.onsuccess = function (e) {
                resolve(result.result);
            }
        }
    });

    const result = await request;
    return result;
}