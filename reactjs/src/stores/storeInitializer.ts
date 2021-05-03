import RoleStore from './roleStore';
import TenantStore from './tenantStore';
import UserStore from './userStore';
import SessionStore from './sessionStore';
import AuthenticationStore from './authenticationStore';
import AccountStore from './accountStore';
import RoomStore from './roomStore';
import NewsStore from './newsStore';
import ApartmentStore from './apartmentStore';
import GalleryStore from './galleryStore';
import FoundationStore from "./foundationStore";

export default function initializeStores() {
  return {
    authenticationStore: new AuthenticationStore(),
    roleStore: new RoleStore(),
    tenantStore: new TenantStore(),
    userStore: new UserStore(),
    sessionStore: new SessionStore(),
    accountStore: new AccountStore(),
    roomStore: new RoomStore(),
    newsStore: new NewsStore(),
    apartmentStore: new ApartmentStore(),
    galleryStore: new GalleryStore(),
    foundationStore:new FoundationStore()

  };
}
