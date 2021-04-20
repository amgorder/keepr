<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer>
    <div class="color text text-center p-4">
      Stay Golden
    </div>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
.color{
  background: hsl(150, 99%, 48%);
}

.text{
  color: hsl(50, 99%, 48%);
}

@import "./assets/scss/main.scss";

</style>
