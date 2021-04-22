import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaults() {
    try {
      const res = await api.get('api/vaults')
      console.log(res)
      AppState.vaults = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getVaultsByAccountId() {
    const res = await api.get('account/vaults')
    console.log(res)
    AppState.vaults = res.data
  }

  async createVault(vault) {
    await api.post('api/vaults', vault)
    this.getVaults()
  }
}
export const vaultsService = new VaultsService()
