import CreateRoomInput from './dto/createRoomInput';
import CreateRoomOutput from './dto/createRoomOutput';
import { EntityDto } from '../dto/entityDto';
import { GetAllRoomOutput } from './dto/getAllRoomOutput';
import GetRoomOutput from './dto/getRoomOutput';
import { PagedResultDto } from '../dto/pagedResultDto';
import {PagedRoomResultRequestDto} from './dto/PagedRoomResultRequestDto';
import UpdateRoomInput from './dto/updateRoomInput';
import UpdateRoomOutput from './dto/updateRoomOutput';
import http from '../httpService';

class RoomService {
  public async create(createRoomInput: CreateRoomInput): Promise<CreateRoomOutput> {
    let result = await http.post('api/services/app/Room/Create', createRoomInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/Room/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetRoomOutput> {
    let result = await http.get('api/services/app/Room/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedRoomResultRequestDto): Promise<PagedResultDto<GetAllRoomOutput>> {
    let result = await http.get('api/services/app/Room/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateRoomInput: UpdateRoomInput): Promise<UpdateRoomOutput> {
    let result = await http.put('api/services/app/Room/Update', updateRoomInput);
    return result.data.result;
  }
}

export default new RoomService();
