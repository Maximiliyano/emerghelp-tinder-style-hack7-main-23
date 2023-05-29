import { initializeApp } from 'firebase/app'
import {
  getFirestore,
  doc,
  getDoc,
  setDoc,
  collection,
  getDocs
} from 'firebase/firestore'
const firebaseConfig = {
  apiKey: 'AIzaSyDvDcpNDznI8lxYoj4YVwldt3U7BzCz44E',
  authDomain: 'volonterfr.firebaseapp.com',
  projectId: 'volonterfr',
  storageBucket: 'volonterfr.appspot.com',
  messagingSenderId: '933580120782',
  appId: '1:933580120782:web:25b6e5b2472b972615669f',
  measurementId: 'G-DCKVWZPRD1'
}

const app = initializeApp(firebaseConfig)
const db = getFirestore(app)

const getUser = async (userObj) => {
  const userSnapshot = await getDoc(doc(db, 'users', userObj.email))
  if (userSnapshot.exists()) {
    console.log('success')
    return userSnapshot.data()
  } else {
    const user = {
      email: userObj.email,
      requests: [],
      responses: [],
      coordinates: { x: 0, y: 0 },
      city: '',
      name: 0
    }
    console.log(user)
    await setDoc(doc(db, 'users', userObj.email), user)
    return user
  }
}

const updateUser = async (user) => {
  const userRef = doc(db, 'users', user.email)
  await setDoc(userRef, user)
}

const updateRequest = async (req) => {
  const ref = doc(db, 'requests', req.id)
  await setDoc(ref, req)
}

const getRequests = async () => {
  const res = []
  const querySnapshot = await getDocs(collection(db, 'requests'))
  console.log(querySnapshot)
  querySnapshot.forEach((doc) => {
    // doc.data() is never undefined for query doc snapshots
    console.log(doc.data())
    if (doc.data().status) {
      res.push(doc.data())
    }
  })
  console.log(res)
  return res
  // return querySnapshot.map((doc) => doc.data()).filter(req => req.status)
}

export { getUser, updateUser, updateRequest, db, getRequests }
