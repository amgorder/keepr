<template>
  <div class="ProfilePage container-fluid">
    <div class="row">
      <!-- <div class="col" v-if="state.loading"></div> -->
      <div class="col" v-if="!state.loading && state.profile.name">
        <h1>Welcome to {{ state.profile.name.includes('@') ? state.profile.name.split('@')[0] : state.profile.name }}'s Page </h1>
        <img :src="state.profile.picture" alt="">
      </div>
    </div>
    <div class="row">
      <keep-component class="keep-component" v-for="k in state.keeps" :key="k.id" :keep-prop="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { profilesService } from '../services/ProfilesService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      loading: true,
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps)
    })
    onMounted(() => {
      profilesService.getProfileById(route.params.id)
      state.loading = false
      keepsService.getKeepsByProfileId(route.params.id)
    })
    return { state }
  }
}
</script>

<style scoped>

.keep-component {
  height: 10rem;
  width: 12rem;
  padding: 3px;
  margin: 3px;
  display: inline-block;
 }

.keep-component:nth-child(2n) {
  height: 20rem !important;
  width: 12rem !important;
 }

.keep-component:nth-child(3n) {
  height: 18rem !important;
  width: 12rem !important;
 }
.keep-component:nth-child(4n) {
  height: 15rem !important;
  width: 12rem !important;
 }
</style>
