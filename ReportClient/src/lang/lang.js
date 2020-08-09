import Vue from "vue";
import VueI18n from "vue-i18n";
import vi from "./vi.json";
import en from "./en.json";
import enLocale from 'element-ui/lib/locale/lang/en'
import viLocale from 'element-ui/lib/locale/lang/vi'

Vue.use(VueI18n);
const locale = "vi";
const messages = {
  vi: {
    ...vi,
    ...viLocale
  },
  en: {
    ...en,
    ...enLocale
  }
};
const fallbackLocale = "vi";
const i18n = new VueI18n({
  locale,
  messages,
  fallbackLocale
});
export default i18n;
