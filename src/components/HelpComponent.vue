<template>
  <v-container fluid>
    <v-btn @click="dialog = true" color="success" fab class="float_btn"
      ><v-icon>mdi-plus</v-icon></v-btn
    >

    <v-dialog v-model="dialog" width="800px">
      <v-stepper v-model="e1">
        <v-stepper-header>
          <v-stepper-step :complete="e1 > 1" step="1">
            Інформація
          </v-stepper-step>

          <v-divider></v-divider>

          <v-stepper-step :complete="e1 > 2" step="2">
            Додаткова Інформація
          </v-stepper-step>

          <v-divider></v-divider>

          <v-stepper-step :complete="e1 > 3" step="3">
            Посилання
          </v-stepper-step>

          <v-divider></v-divider>

          <v-stepper-step step="4"> Фото </v-stepper-step>
        </v-stepper-header>

        <v-stepper-items>
          <v-stepper-content step="1">
            <v-card class="mb-12" color="grey lighten-1" height="250px">
              <div id="app">
                <v-app id="inspire">
                  <v-form ref="form" lazy-validation>
                    <v-text-field
                      v-model="request.phone"
                      :counter="13"
                      label="Номер телефону"
                      type="tel"
                      required
                    ></v-text-field>

                    <v-text-field
                      label="Причина звернення?"
                      v-model="request.title"
                      required
                    ></v-text-field>
                    <v-combobox
                      label="Місто"
                      required
                      v-model="request.city"
                      :items="
                        [
                          'Луцьк',
                          'Луганськ',
                          'Маріуполь',
                          'Сімферополь',
                          'Херсон',
                          'Дніпро',
                          'Кременчук',
                          'Суми',
                          'Черкаси',
                          'Кіровоград',
                          'Миколаїв',
                          'Чернігів',
                          'Київ',
                          'Біла Церква',
                          'Умань',
                          'Чернівці',
                          'Ужгород',
                          'Вінниця',
                          'Житомир',
                          'Івано-Франківськ',
                          'Тернопіль',
                          'Львів',
                        ].sort((a, b) => a.localeCompare(b))
                      "
                    ></v-combobox>
                    <v-text-field label="Адреса" required></v-text-field>
                  </v-form>
                </v-app>
              </div>
            </v-card>

            <v-btn color="primary" @click="e1 = 2"> Додати інформацію </v-btn>

            <v-btn color="red" text @click="newRequest()"> Пропустити </v-btn>
          </v-stepper-content>

          <v-stepper-content step="2">
            <v-card class="mb-12" color="grey lighten-1" height="200px">
              <div id="app">
                <v-app id="inspire">
                  <v-form ref="form" lazy-validation>
                    <v-text-field
                      v-model="request.author"
                      label="Прізвище та ім'я"
                      required
                    ></v-text-field>

                    <v-textarea label="Опис" required rows="2"></v-textarea>

                    <v-combobox
                      v-model="request.category"
                      multiple
                      :items="['Food', 'Transportation', 'Injury']"
                      label="Категорія"
                      required
                    ></v-combobox>
                  </v-form>
                </v-app>
              </div>
            </v-card>

            <v-btn color="primary" @click="e1 = 3"> Додати посилання </v-btn>

            <v-btn text color="red" @click="newRequest()"> Пропустити </v-btn>
          </v-stepper-content>

          <v-stepper-content step="3">
            <v-card class="mb-12" color="grey lighten-1" height="350px">
              <div id="app">
                <v-app id="inspire">
                  <v-form ref="form" lazy-validation>
                    <v-text-field
                      :v-model="request.social.telegram"
                      label="Telegram"
                    ></v-text-field>
                    <v-text-field
                      :v-model="request.social.instagram"
                      label="Instagram"
                    ></v-text-field>
                    <v-text-field
                      :v-model="request.social.facebook"
                      label="Facebook"
                    ></v-text-field>
                    <v-text-field
                      :v-model="request.social.twitter"
                      label="Twitter"
                    ></v-text-field>
                    <v-text-field
                      :v-model="request.social.other"
                      label="Інші"
                    ></v-text-field>
                  </v-form>
                </v-app>
              </div>
            </v-card>

            <v-btn color="primary" @click="e1 = 4"> Додати фото </v-btn>

            <v-btn text color="red" @click="newRequest()"> Пропустити </v-btn>
          </v-stepper-content>

          <v-stepper-content step="4">
            <v-card class="mb-12" color="grey lighten-1" height="200px">
              <div id="app">
                <v-app id="inspire">
                  <v-form ref="form" lazy-validation>
                    <v-file-input
                      label="Завантажити фото"
                      @change="onFileSelected"
                    ></v-file-input>

                    <v-img
                      v-if="selectedImage"
                      :src="selectedImage"
                      height="200"
                      contain
                    ></v-img>
                  </v-form>
                </v-app>
              </div>
            </v-card>

            <v-btn color="primary" @click="newRequest()"> Опублікувати </v-btn>
          </v-stepper-content>
        </v-stepper-items>
      </v-stepper>
    </v-dialog>

    <v-row>
      <v-col
        cols="12"
        md="6"
        lg="4"
        v-for="data in products"
        v-bind:key="data.id"
      >
        <v-card class="w100" :key="data.img" tile>
          <v-card tile>
            <v-img
              v-if="!data.flipped"
              class="rand white--text align-end"
              max-height="75vh"
              :src="getImgUrl(data.image)"
              gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
            >
              <v-card-title class="pb-2">Broken leg</v-card-title>

              <v-card-text>
                <v-chip
                  class="mb-4 mr-1"
                  v-for="i in ['Медикаменти', 'Їжа']"
                  :key="i"
                  >{{ i }}</v-chip
                >

                <v-row justify="center" align="center" class="my-4 mx-0">
                  <v-btn fab dark @click="data.flipped = !data.flipped"
                    ><v-icon dark> mdi-rotate-360 </v-icon></v-btn
                  ></v-row
                >
              </v-card-text>
            </v-img>
            <div v-else class="h75">
              <v-row justify="space-between" align="center" class="ma-0">
                <v-card-title class="pb-2">Broken leg</v-card-title>
                <v-btn
                  color="black"
                  icon
                  dark
                  @click="data.flipped = !data.flipped"
                  ><v-icon> mdi-rotate-360 </v-icon></v-btn
                >
              </v-row>

              <v-card-text>
                <v-chip
                  class="mb-4 mr-1"
                  v-for="i in ['Медикаменти', 'Їжа']"
                  :key="i"
                  >{{ i }}</v-chip
                >

                <v-row justify="space-between" align="center" class="ma-0"
                  ><div class="text-subtitle-1">Lviv, 20 km from you</div>
                </v-row>
                <div class="black--text font-weight-bold">Dmytro Romanenko</div>
                <a
                  href="tel:+380 66 343 22 34"
                  class="text-subtitle-2 grey--text text-decoration-none"
                >
                  +380 66 343 22 34
                </a>
              </v-card-text>
              <v-card-text v-if="true" class="d-flex my-0 py-0 justify-start">
                <a href="http://t.me/romnnko">
                  <v-btn color="blue" icon dark
                    ><v-icon class="rotate45 mb-1">mdi-send</v-icon></v-btn
                  >
                </a>
                <a>
                  <v-btn color="purple" icon dark
                    ><v-icon>mdi-instagram</v-icon></v-btn
                  >
                </a>
                <a>
                  <v-btn color="blue" icon dark
                    ><v-icon>mdi-facebook</v-icon></v-btn
                  >
                </a>
                <a href="http://t.me/romnnko">
                  <v-btn color="blue" icon dark
                    ><v-icon>mdi-twitter</v-icon></v-btn
                  >
                </a>
                <a href="http://t.me/romnnko">
                  <v-btn color="grey" icon dark><v-icon>mdi-web</v-icon></v-btn>
                </a>
              </v-card-text>
              <v-card-text
                v-else
                class="d-flex my-0 py-0 justify-start font-weight-bold"
              >
                Користувач не додав корисних посилань
              </v-card-text>
              <v-card-text class="text-caption"> 19.05.2023 17:55 </v-card-text>
              <v-card-text class="desc py-0 my-4">
                <div class="black--text">
                  I have broke my leg, and I need somebody to help me I have
                  broke my leg, and I need somebody to help me I have broke my
                  leg, and I need somebody to help me I have broke my leg, and I
                  need somebody to help me I have broke my leg, and I need
                  somebody to help me I have broke my leg, and I need somebody
                  to help me I have broke my leg, and I need somebody to help me
                  I have broke my leg, and I need somebody to help me I have
                  broke my leg, and I need somebody to help me I have broke my
                  leg, and I need somebody to help me I have broke my leg, and I
                  need somebody to help me I have broke my leg, and I need
                  somebody to help me
                </div>
              </v-card-text>
              <div class="d-flex flex-column align-center justify-end" column>
                <v-btn color="primary" text class="mb-4" @click="dialog=true; request=[...data]">Редагувати</v-btn>
              </div>
            </div>
          </v-card>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapGetters, mapMutations } from 'vuex'
import { v4 as uuidv4 } from 'uuid'
import { updateUser, updateRequest, db } from '@/firebaseDb'
import { collection, addDoc } from 'firebase/firestore'
import { getStorage, ref, uploadBytes } from 'firebase/storage'
import source from '@/assets/showroom.json'
import yesTxt from '@/assets/showroom/yes-txt.png'
import noTxt from '@/assets/showroom/no-txt.png'
import maybeTxt from '@/assets/showroom/maybe-txt.png'
import retryTxt from '@/assets/showroom/retry-txt.png'

export default {
  name: 'HelpComponent',
  components: {},
  data () {
    return {
      show: -1,
      date1: null,
      date2: null,
      edit: -1,
      dialog: false,
      newCredit: {
        id: '',
        startDate: '',
        endDate: '',
        percentage: '',
        bankName: '',
        total: ''
      },
      yesTxt: yesTxt,
      noTxt: noTxt,
      maybeTxt: maybeTxt,
      retryTxt: retryTxt,
      products: [],
      offset: 0,
      history: [],
      buttons: 'solid',
      background: false,
      title: 'top',
      productOut: true,
      randomImg: '',
      e1: 1,
      selectedImage: '',
      request: {
        phone: '',
        address: '',
        city: '',
        social: {
          telegram: {
            stringValue: 'https://web.telegram.org/a/'
          },
          instagram: {
            stringValue: 'https://www.instagram.com'
          }
        },
        title: '',
        description: '',
        author: '',
        category: '',
        time: '',
        coordinates: {
          x: 0,
          y: 0
        },
        status: true
      }
    }
  },
  async created () {
    await this.getUserData(this.$auth.user)
    this.getProducts()
    this.request.city = this.user.city
    this.request.author = this.$auth.user.name
  },
  methods: {
    ...mapMutations([
      'setFilteredOperations',
      'setOperations',
      'setLoading',
      'showSnackbar',
      'setSnackbar',
      'setUser'
    ]),
    onFileSelected (file) {
      this.selectedFile = file
    },
    uploadImage () {
      const storage = getStorage()
      const storageRef = ref(storage, 'images/' + this.selectedFile.name)

      const metadata = {
        contentType: this.selectedFile.type
      }

      const uploadTask = uploadBytes(storageRef, this.selectedFile, metadata)
      uploadTask.on(
        'state_changed',
        () => {},
        (error) => {
          console.error(error)
        },
        () => {
          uploadTask.snapshot.ref.getDownloadURL().then((downloadURL) => {
            this.imageUrl = downloadURL

            const imagesCollection = collection(db, 'images')
            const imageDocData = {
              url: downloadURL
            }

            addDoc(imagesCollection, imageDocData)
              .then((docRef) => {
                console.log('Document written with ID: ', docRef.id)
              })
              .catch((error) => {
                console.error('Error adding document: ', error)
              })
          })
        }
      )
    },
    async newRequest () {
      const currentDate = new Date()

      const day = String(currentDate.getDate()).padStart(2, '0')
      const month = String(currentDate.getMonth() + 1).padStart(2, '0') // Months are zero-based
      const year = currentDate.getFullYear()

      const hours = String(currentDate.getHours()).padStart(2, '0')
      const minutes = String(currentDate.getMinutes()).padStart(2, '0')

      this.request.date = `${day}.${month}.${year}`
      this.request.time = `${hours}:${minutes}`
      this.request.id = uuidv4()
      console.log(1)
      await updateRequest(this.request)
      console.log(3)
      updateUser({ ...this.user, requests: this.user.request?.push(this.request) ?? [this.request] })
      console.log(4)
      // await this.uploadImage()
      this.dialog = false
    },
    generateImg () {
      return 'https://picsum.photos/300/200'
    },
    getProducts: function () {
      this.products = []
      try {
        const list = []
        const newSource = source.filter((element) => Boolean(element.active))

        for (let i = 0; i < newSource.length - 1; i++) {
          const obj = {
            id: i,
            image: `fotor1${i + 1}.jpg`,
            isProduct: true,
            flipped: false
          }
          list.push(obj)
        }
        this.products = this.products.concat(list)
      } catch (err) {
        console.log(err)
      }
    },
    getImgUrl (pic) {
      return require('@/assets/showroom/' + pic)
    },
    getTextImageUrl: function ({ name }) {
      return name.toLowerCase().replace(' ', '_') + '.jpg'
    },
    decide: function (choice) {
      const a = navigator.geolocation.getCurrentPosition((b) => console.log(b))
      console.log(a)
      if (choice === 'rewind') {
        const length = this.history.length
        const el = this.history.pop()
        console.log(el)
        if (length) {
          this.$refs.showroom.rewind([el])
        }
      } else {
        console.log(choice)
        this.$refs.showroom.decide(choice)
      }
      this.randomImg = this.generateImg()
    },
    onSubmit (data) {
      if (this.products.length === 0) {
        this.goToCatalog()
      }
      this.history.push(data.item)
      if (data.type) {
        console.log(data.item)
        console.log(data.type)
      }
    },
    goToCatalog: function () {
      this.$router.go(this.$router.currentRoute)
    },
    async getUserData (user) {
      if (!this.loading) {
        try {
          await this.$store.dispatch('getUserInfo', user)
        } catch (e) {
          console.log(e)
          this.showSnackbar({
            message:
              'Error occurred while fetching resources, refresh the page or try again later',
            color: 'error'
          })
        } finally {
          this.setLoading(false)
        }
      }
    },
    addCredit () {
      console.log(this.newCredit)
      this.newCredit.id = uuidv4()
      this.newCredit.startDate = this.newCredit.startDate
        .split('-')
        .reverse()
        .join('.')
      this.newCredit.endDate = this.newCredit.endDate
        .split('-')
        .reverse()
        .join('.')
      this.user.credits.unshift(this.newCredit)
      updateUser(this.user)
      this.dialog = false
    },
    confirmAdd () {},
    saveCredit (credit, index) {
      credit.startDate = this.date1.split('-').reverse().join('.')
      credit.endDate = this.date2.split('-').reverse().join('.')
      this.show = -1
      this.edit = -1
      updateUser(this.user)
      // update here
    },
    editCredit (credit, index) {
      this.show = index
      this.edit = index
      this.date1 = credit.startDate.split('.').reverse().join('-')
      this.date2 = credit.endDate.split('.').reverse().join('-')
    },
    deleteCredit (index) {
      this.show = -1
      this.edit = -1
      this.user.credits.splice(index, 1)
      updateUser(this.user)
    },
    getDateDifference (date1, date2) {
      const [day1, month1, year1] = date1.split('.')
      const [day2, month2, year2] = date2.split('.')

      const dateObj1 = new Date(`${year1}-${month1}-${day1}`)
      const dateObj2 = new Date(`${year2}-${month2}-${day2}`)

      const diffMonths =
        (dateObj2.getFullYear() - dateObj1.getFullYear()) * 12 +
        (dateObj2.getMonth() - dateObj1.getMonth())
      return diffMonths || 1
    },
    calculateCreditPayment (credit) {
      const percentage = credit.percentage
      const initialSum = credit.total
      const monthTerm = this.getTerm(credit)
      const monthlyInterestRate = percentage / 12 / 100

      const monthlyPayment =
        initialSum * monthlyInterestRate + initialSum / monthTerm
      console.log(monthlyPayment)
      return Number(monthlyPayment.toFixed(2))
    },
    getTerm (credit) {
      return this.getDateDifference(credit.startDate, credit.endDate)
    }
  },
  computed: {
    ...mapGetters([
      'loading',
      'filteredOperations',
      'filterParams',
      'user',
      'operations'
    ])
  }
}
</script>

<style lang="css" scoped>
.float_btn {
  position: fixed;
  right: 50px;
  bottom: 50px;
  z-index: 1000;
}
.inputPrice >>> input[type="number"] {
  -moz-appearance: textfield;
}
.inputPrice >>> input::-webkit-outer-spin-button,
.inputPrice >>> input::-webkit-inner-spin-button {
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
}
/* width */
::-webkit-scrollbar {
  width: 10px;
}

/* Track */
::-webkit-scrollbar-track {
  background: #f1f1f1;
}

/* Handle */
::-webkit-scrollbar-thumb {
  background: #888;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #555;
}
.desc {
  max-height: 20vh;
  overflow-x: hidden; /* Hide horizontal scrollbar */
  overflow-y: scroll;
}
.rotate45 {
  transform: rotate(-45deg);
}
.h75 {
  max-height: 75vh;
}
.w100 {
  width: 100%;
  position: relative;
  cursor: pointer;
  max-height: 75vh;
  z-index: 2;
  -webkit-box-shadow: -11px 49px 42px -26px rgba(168, 168, 168, 1);
  -moz-box-shadow: -11px 49px 42px -26px rgba(168, 168, 168, 1);
  box-shadow: -11px 49px 42px -26px rgba(168, 168, 168, 1);
  will-change: transform;
}
.flip-enter-active {
  transition: all 1s ease;
}

.flip-leave-active {
  display: none;
}

.flip-enter,
.flip-leave {
  transform: rotateY(180deg);
  opacity: 0;
}
.vue-tinder {
  position: absolute;
  margin: auto;
  z-index: 1;
  left: 0;
  right: 0;
  top: 5px;
  width: 100%;
  height: 100%;
  min-width: 350px;
  max-width: 350px;
}

.nope-pointer,
.like-pointer {
  position: absolute;
  z-index: 6;
  top: 30px;
  width: 96px;
  height: 96px;
  transition: all 1s ease;
}

.nope-pointer {
  right: 10px;
}

.like-pointer {
  left: 10px;
}

.super-pointer {
  transition: all 1s ease;
  position: absolute;
  z-index: 6;
  bottom: 0px;
  left: 80px;
  right: 0;
  margin: auto;
  width: 112px;
  height: 100px;
}

.rewind-pointer {
  position: absolute;
  z-index: 1;
  top: 30px;
  right: 10px;
  width: 96px;
  height: 96px;
}

.btns {
  position: relative;
  left: 0;
  bottom: 70px;
  z-index: 3;
  margin: auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.pic {
  width: 100%;
  height: 100%;
  background-size: cover;
  background-repeat: no-repeat;
  background-position: center;
}
.bg-card {
  color: #fff;
  background: -webkit-linear-gradient(150deg, #d9a94c 66%, #eae2c0 66%);
  background: -o-linear-gradient(150deg, #d9a94c 66%, #eae2c0 66%);
  background: -moz-linear-gradient(150deg, #d9a94c 66%, #eae2c0 66%);
  background: linear-gradient(150deg, #d9a94c 66%, #eae2c0 66%);
}

.item-name {
  position: relative;
  display: flex;
  flex-direction: column;
}

.rand {
  width: 100%;
}
</style>
