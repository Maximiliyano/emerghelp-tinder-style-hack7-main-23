<template>
    <v-container class="fill-height" fluid>
      <v-row class="px-4">
      <v-col class="d-flex align-center flex-column justify-center">
        <v-img max-width="350px" src="../../public/logo_black.png"></v-img>
        <h1 class="mb-5 text-center">Swipe2Help is a tinder style help search service.</h1>
        <v-btn x-large rounded class="green white--text large mb-4" v-if="!$auth.isAuthenticated"
            ref="loginBtn"
            to="/login">Get Started</v-btn>
        <v-divider></v-divider>
        <h2>Our advantages</h2>
        <v-row class="mb-5 ma-1">
        <v-chip
        class="my-4 mx-4"
        color="primary"
        outlined
      >
        Comfort to use
      </v-chip>
       <v-chip
        class="my-4 mx-2"
        color="primary"
        outlined
      >
        Innovate
      </v-chip>
       </v-row>
        <p style="font-size: 18px;">A tinder-style application has been developed to simplify the request for help.</p>
        <p style="font-size: 18px; " class="mb-5">Our target audience is primarily volunteers</p>
      </v-col>
      <v-col cols="12" sm="9" class="pt-sm-3 pt-0"></v-col>
    </v-row>
    </v-container>
</template>

<script>
export default {
  name: 'AboutPage'
}
</script>

<style scoped></style>
