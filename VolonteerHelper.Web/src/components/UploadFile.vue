<template>
  <div>
    <input type="file" @change="handleFileUpload">
    <button @click="uploadImage">Upload</button>
  </div>
</template>

<script>
import { getStorage, ref, uploadBytes } from "firebase/storage";
import { db } from '@/firebaseDb';

export default {
  data() {
    return {
      selectedFile: null,
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
           
            db.collection('images').add({ url: downloadURL });
          });
        }
      );
    },
  },
};
</script>
