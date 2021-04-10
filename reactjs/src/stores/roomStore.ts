import { action, observable } from 'mobx';
import CreateRoomInput from '../services/room/dto/createRoomInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllRoomOutput } from '../services/room/dto/getAllRoomOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedRoomResultRequestDto } from '../services/room/dto/PagedRoomResultRequestDto';
import RoomModel from '../models/Rooms/RoomModel';
import UpdateRoomInput from '../services/room/dto/updateRoomInput';
import roomService from '../services/room/roomService';

class RoomStore {
  @observable rooms!: PagedResultDto<GetAllRoomOutput>;
  @observable roomModel: RoomModel = new RoomModel();

  @action
  async create(createRoomInput: CreateRoomInput) {
    await roomService.create(createRoomInput);
  }

  @action
  async createRoom() {
    this.roomModel = {
      id: 0,
      image1: '',
      image2: '',
      image3: '',
      image4: '',
      image5: '',
      name: '',
      description: '',
      bed: 0,  
      length: 0,  
      bath: 0,  
      imageSequence: 0,
      price: '',
      categoryName:""
    };
  }

  @action
  async update(updateRoomInput: UpdateRoomInput) {
    let result = await roomService.update(updateRoomInput);

    this.rooms.items = this.rooms.items.map((x: GetAllRoomOutput) => {
      if (x.id === updateRoomInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await roomService.delete(entityDto);
    this.rooms.items = this.rooms.items.filter((x: GetAllRoomOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await roomService.get(entityDto);
    this.roomModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedRoomResultRequestDto) {
    let result = await roomService.getAll(pagedFilterAndSortedRequest);
    this.rooms = result;
  }
}

export default RoomStore;
