<template>
  <div>
    <input type="file" @change="handleFileUpload">
    <button @click="uploadImage">Upload</button>
    <button @click="getImage">Get Image</button>
    <div v-if="imageUrl">
      <img :src="imageUrl" alt="Uploaded Image">
    </div>
  </div>
</template>

<script>
import { collection, addDoc } from "firebase/firestore";
import { getStorage, ref, uploadBytes, getDownloadURL } from "firebase/storage";
import { db } from '@/firebaseDb';

export default {
  data() {
    return {
      selectedFile: null,
      imageUrl: null
    };
  },
  methods: {
    handleFileUpload(event) {
      this.selectedFile = event.target.files[0];
    },
    uploadImage() {
      const storage = getStorage();
      const storageRef = ref(storage, 'images/' + this.selectedFile.name);

      const metadata = {
        contentType: this.selectedFile.type,
      };

      const uploadTask = uploadBytes(storageRef, this.selectedFile, metadata);

      uploadTask.on('state_changed',
        () => {
          
        },
        (error) => {
          
          console.error(error);
        },
        () => {
          uploadTask.snapshot.ref.getDownloadURL().then((downloadURL) => {
            this.imageUrl = downloadURL;
           
            const imagesCollection = collection(db, "images");
            const imageDocData = {
              url: downloadURL
            };

            addDoc(imagesCollection, imageDocData)
              .then((docRef) => {
                console.log("Document written with ID: ", docRef.id);
              })
              .catch((error) => {
                console.error("Error adding document: ", error);
              });
                });
        }
      );
    },
    getImage() {
      const storage = getStorage();
      const storageRef = ref(storage, 'images/' + this.selectedFile.name);

      getDownloadURL(storageRef).then((downloadURL) => {
        this.imageUrl = downloadURL;
      }).catch((error) => {
        console.error(error);
      });
    },
  },
};
</script>
