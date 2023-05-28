import { initializeApp } from 'firebase/app'
import { getFirestore, doc, getDoc, setDoc } from 'firebase/firestore'

const firebaseConfig = {
  apiKey: "AIzaSyDvDcpNDznI8lxYoj4YVwldt3U7BzCz44E",
  authDomain: "volonterfr.firebaseapp.com",
  projectId: "volonterfr",
  storageBucket: "volonterfr.appspot.com",
  messagingSenderId: "933580120782",
  appId: "1:933580120782:web:25b6e5b2472b972615669f",
  measurementId: "G-DCKVWZPRD1"
};

const app = initializeApp(firebaseConfig);
const db = getFirestore(app);

const getUser = async (email) => {
  const userSnapshot = await getDoc(doc(db, 'users', email))
  if (userSnapshot.exists()) {
    console.log('success')
    return userSnapshot.data()
  } else {
    const user = { email: email, credits: [], deposits: [], operations: [], total: 0 }
    console.log(user)
    await setDoc(doc(db, 'users', email), user)
    return user
  }
}

const updateUser = async (user) => {
  const userRef = doc(db, 'users', user.email)
  await setDoc(userRef, {
    email: user.email,
    credits: user.credits,
    deposits: user.deposits,
    operations: user.operations,
    total: user.total
  })
}


export { db, app, getUser, updateUser }