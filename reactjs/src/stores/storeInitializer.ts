import RoleStore from './roleStore';
import TenantStore from './tenantStore';
import UserStore from './userStore';
import SessionStore from './sessionStore';
import AuthenticationStore from './authenticationStore';
import AccountStore from './accountStore';
import CategoryStore from './categoryStore';
import TagStore from './tagStore';
import AuthorStore from './authorStore';
import ArticleStore from './articleStore';

export default function initializeStores() {
  return {
    authenticationStore: new AuthenticationStore(),
    roleStore: new RoleStore(),
    tenantStore: new TenantStore(),
    userStore: new UserStore(),
    sessionStore: new SessionStore(),
    accountStore: new AccountStore(),
    categoryStore: new CategoryStore(),
    tagStore: new TagStore(),
    authorStore: new AuthorStore(),
    articleStore: new ArticleStore()
  };
}
