<template>
  <div class="grid-item">
    <router-link class="text-dark" :to="{name: 'VaultPage', params: {vaultId : vaultProp.id}}">
      <div class="vaultComponent card text-dark h-100 w-100 " :style="{ backgroundImage: `url('${vaultProp.img}')`, backgroundSize: 'cover' , backgroundRepeat: 'no-repeat'}">
        <h3>
          {{ vaultProp.name }}
        </h3>
      </div>
    </router-link>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'VaultComponent',
  props: {
    vaultProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {
      state,
      // delete in the vault page
      deleteVault() {
        vaultsService.deleteVault(props.vaultProp.id)
      }
    }
  }
}
</script>

<style>
/* .grid-item { width: 100px; } */

/* .card {
  width: 200px;

  padding: 3px;
  margin: 3px;
} */

/* .bg-img{
  background-image: url("vaultProp.img");
} */

.pic{
  display: inline-block;
  padding: 4px;

  background: linear-gradient(130deg,  hsl(150, 99%, 48%), hsl(150, 99%, 48%));
  object-fit: cover;
  margin: auto;
  border-radius: 50%;
  width: 50px;
  height:50px;
  box-shadow: 6px,6px,12px,16px black;
}
</style>
