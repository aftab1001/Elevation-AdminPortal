import { action, observable } from 'mobx';
import CreateApartmentInput from '../services/apartment/dto/createApartmentInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllApartmentOutput } from '../services/apartment/dto/getAllApartmentOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedApartmentResultRequestDto } from '../services/apartment/dto/PagedApartmentResultRequestDto';
import ApartmentModel from '../models/Apartments/ApartmentModel';
import UpdateApartmentInput from '../services/apartment/dto/updateApartmentInput';
import apartmentService from '../services/apartment/apartmentService';

class ApartmentStore {
  @observable apartments!: PagedResultDto<GetAllApartmentOutput>;
  @observable apartmentModel: ApartmentModel = new ApartmentModel();

  @action
  async create(createApartmentInput: CreateApartmentInput) {
    await apartmentService.create(createApartmentInput);
  }

  @action
  async createApartment() {
    this.apartmentModel = {
      id: 0,
      isActive: true,
      name: '',
      tenancyName: '',
    };
  }

  @action
  async update(updateApartmentInput: UpdateApartmentInput) {
    let result = await apartmentService.update(updateApartmentInput);

    this.apartments.items = this.apartments.items.map((x: GetAllApartmentOutput) => {
      if (x.id === updateApartmentInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await apartmentService.delete(entityDto);
    this.apartments.items = this.apartments.items.filter((x: GetAllApartmentOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await apartmentService.get(entityDto);
    this.apartmentModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedApartmentResultRequestDto) {
    let result = await apartmentService.getAll(pagedFilterAndSortedRequest);
    this.apartments = result;
  }
}

export default ApartmentStore;
