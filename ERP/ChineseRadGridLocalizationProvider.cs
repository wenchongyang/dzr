using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI.Localization;

namespace ERP
{
    public class ChineseRadGridLocalizationProvider : RadGridLocalizationProvider
    {
        /// <summary>
        /// 重写的本地化取值方法。
        /// </summary>
        /// <param name="id">功能键值。</param>
        /// <returns>本地化串。</returns>
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadGridStringId.AddNewRowString:
                    return "点击添加新行";
                case RadGridStringId.BestFitMenuItem:
                    return "自适应列宽";
                case RadGridStringId.ClearValueMenuItem:
                    return "清  空";
                case RadGridStringId.CompositeFilterFormErrorCaption:
                    return "多功能过滤器错误标题";
                case RadGridStringId.ClearSortingMenuItem:
                    return "清除排序";
                case RadGridStringId.CopyMenuItem:
                    return "复  制";
                case RadGridStringId.ColumnChooserFormCaption:
                    return " 列选择表格标题";
                case RadGridStringId.ColumnChooserFormMessage:
                    return "当前视图中，从网格中拖动列标题到这里并删除\n如果想加到网格中再次拖动即可";
                case RadGridStringId.ColumnChooserMenuItem:
                    return "列选择";
                case RadGridStringId.ConditionalFormattingBtnExpression:
                    return "表达式";
                case RadGridStringId.ConditionalFormattingLblFormat:
                    return "标签格式";
                case RadGridStringId.ConditionalFormattingPropertyGridCaseSensitive:
                    return "区分大小写";
                case RadGridStringId.ConditionalFormattingPropertyGridCellBackColor:
                    return "背景色";
                case RadGridStringId.ConditionalFormattingPropertyGridCellForeColor:
                    return "前景色";
                case RadGridStringId.ConditionalFormattingPropertyGridEnabled:
                    return "启用";
                case RadGridStringId.ConditionalFormattingPropertyGridRowBackColor:
                    return "行背景色";
                case RadGridStringId.ConditionalFormattingPropertyGridRowForeColor:
                    return "行前景色";
                case RadGridStringId.ConditionalFormattingPropertyGridRowTextAlignment:
                    return "行文本对齐";
                case RadGridStringId.ConditionalFormattingPropertyGridTextAlignment:
                    return "文本对齐";
                case RadGridStringId.ConditionalFormattingSortAlphabetically:
                    return "按字母顺序排序";
                case RadGridStringId.ConditionalFormattingStartsWith:
                    return "起始为";
                case RadGridStringId.ConditionalFormattingTextBoxExpression:
                    return "表达式";
                case RadGridStringId.ConditionalFormattingMenuItem:
                    return "条件格式";
                case RadGridStringId.ConditionalFormattingCaption:
                    return "条件格式标题";
                case RadGridStringId.ConditionalFormattingLblColumn:
                    return "标签列:";
                case RadGridStringId.ConditionalFormattingLblName:
                    return "标签名:";
                case RadGridStringId.ConditionalFormattingLblType:
                    return "标签类型:";
                case RadGridStringId.ConditionalFormattingRuleAppliesOn:
                    return "规则适用于:";
                case RadGridStringId.ConditionalFormattingChooseOne:
                    return "选择一个";
                case RadGridStringId.ConditionalFormattingCondition:
                    return "条件";
                case RadGridStringId.ConditionalFormattingContains:
                    return "包含";
                case RadGridStringId.ConditionalFormattingDoesNotContain:
                    return "不包含";
                case RadGridStringId.ConditionalFormattingEndsWith:
                    return "结束于";
                case RadGridStringId.ConditionalFormattingEqualsTo:
                    return "等于";
                case RadGridStringId.ConditionalFormattingExpression:
                    return "表达式";
                case RadGridStringId.ConditionalFormattingIsBetween:
                    return "之间";
                case RadGridStringId.ConditionalFormattingIsGreaterThan:
                    return "大于";
                case RadGridStringId.ConditionalFormattingIsGreaterThanOrEqual:
                    return "大于等于";
                case RadGridStringId.ConditionalFormattingIsLessThan:
                    return "小于";
                case RadGridStringId.ConditionalFormattingIsLessThanOrEqual:
                    return "小于等于";
                case RadGridStringId.ConditionalFormattingIsNotBetween:
                    return "不在之间";
                case RadGridStringId.ConditionalFormattingIsNotEqualTo:
                    return "不等于";
                case RadGridStringId.ConditionalFormattingLblValue1:
                    return "标签值1:";
                case RadGridStringId.ConditionalFormattingLblValue2:
                    return "标签值2:";
                case RadGridStringId.ConditionalFormattingGrpConditions:
                    return "分组条件:";
                case RadGridStringId.ConditionalFormattingGrpProperties:
                    return "分组属性";
                case RadGridStringId.ConditionalFormattingChkApplyToRow:
                    return "选中适用于行";
                case RadGridStringId.ConditionalFormattingBtnAdd:
                    return "添加";
                case RadGridStringId.ConditionalFormattingBtnRemove:
                    return "删除";
                case RadGridStringId.ConditionalFormattingBtnOK:
                    return "确定";
                case RadGridStringId.ConditionalFormattingBtnCancel:
                    return "取消";
                case RadGridStringId.ConditionalFormattingBtnApply:
                    return "应用";
                case RadGridStringId.ConditionalFormattingChkApplyOnSelectedRows:
                    return "选中适用于选中行";
                case RadGridStringId.CustomFilterDialogBtnCancel:
                    return "取消";
                case RadGridStringId.CustomFilterDialogBtnOk:
                    return "确定";
                case RadGridStringId.CustomFilterDialogFalse:
                    return "假";
                case RadGridStringId.CustomFilterDialogRbAnd:
                    return "和";
                case RadGridStringId.CustomFilterDialogRbOr:
                    return "或";
                case RadGridStringId.CustomFilterDialogTrue:
                    return "真";
                case RadGridStringId.CustomFilterMenuItem:
                    return "菜单项";
                case RadGridStringId.CustomFilterDialogCheckBoxNot:
                    return "是  否";
                case RadGridStringId.CustomFilterDialogLabel:
                    return "显示的列";
                case RadGridStringId.CutMenuItem:
                    return "剪切";
                case RadGridStringId.CustomFilterDialogCaption:
                    return "自定义条件";
                case RadGridStringId.DeleteRowMenuItem:
                    return "删除行";
                case RadGridStringId.EditMenuItem:
                    return "编  辑";
                case RadGridStringId.ExpressionFormAndButton:
                    return "和";
                case RadGridStringId.ExpressionFormCancelButton:
                    return "取消";
                case RadGridStringId.ExpressionFormConstants:
                    return "包含";
                case RadGridStringId.ExpressionFormDescription:
                    return "描述";
                case RadGridStringId.ExpressionFormFields:
                    return "字段";
                case RadGridStringId.ExpressionFormFunctions:
                    return "函数";
                case RadGridStringId.ExpressionFormFunctionsAggregate:
                    return "合计";
                case RadGridStringId.ExpressionFormFunctionsDateTime:
                    return "日期时间";
                case RadGridStringId.ExpressionFormFunctionsLogical:
                    return "逻辑";
                case RadGridStringId.ExpressionFormFunctionsMath:
                    return "数学";
                case RadGridStringId.ExpressionFormFunctionsOther:
                    return "其它";
                case RadGridStringId.ExpressionFormFunctionsText:
                    return "文本";
                case RadGridStringId.ExpressionFormNotButton:
                    return "没有";
                case RadGridStringId.ExpressionFormOKButton:
                    return "确定";
                case RadGridStringId.ExpressionFormOperators:
                    return "运营商";
                case RadGridStringId.ExpressionFormOrButton:
                    return "或";
                case RadGridStringId.ExpressionFormResultPreview:
                    return "结果预览";
                case RadGridStringId.ExpressionFormTitle:
                    return "主题";
                case RadGridStringId.ExpressionFormTooltipAnd:
                    return "与";
                case RadGridStringId.ExpressionFormTooltipDivide:
                    return "除以";
                case RadGridStringId.ExpressionFormTooltipEqual:
                    return "等于";
                case RadGridStringId.ExpressionFormTooltipGreater:
                    return "大于";
                case RadGridStringId.ExpressionFormTooltipGreaterOrEqual:
                    return "大于等于";
                case RadGridStringId.ExpressionFormTooltipLess:
                    return "小于";
                case RadGridStringId.ExpressionFormTooltipLessOrEqual:
                    return "小于等于";
                case RadGridStringId.ExpressionFormTooltipMinus:
                    return "减去";
                case RadGridStringId.ExpressionFormTooltipModulo:
                    return "模";
                case RadGridStringId.ExpressionFormTooltipMultiply:
                    return "乘以";
                case RadGridStringId.ExpressionFormTooltipNot:
                    return "否";
                case RadGridStringId.ExpressionFormTooltipNotEqual:
                    return "不等于";
                case RadGridStringId.ExpressionFormTooltipOr:
                    return "或";
                case RadGridStringId.ExpressionFormTooltipPlus:
                    return "加";
                case RadGridStringId.ExpressionMenuItem:
                    return "表达式菜单项";
                case RadGridStringId.HideGroupMenuItem:
                    return "隐藏分组菜单项";
                case RadGridStringId.HideMenuItem:
                    return "隐  藏";
                case RadGridStringId.PinAtBottomMenuItem:
                    return "页脚在下面的菜单项";
                case RadGridStringId.PinAtTopMenuItem:
                    return "页脚顶部菜单项";
                case RadGridStringId.UnpinRowMenuItem:
                    return "取消固定行菜单项";
                case RadGridStringId.GroupByThisColumnMenuItem:
                    return "分  组";
                case RadGridStringId.FilterFunctionContains:
                    return "包  含";
                case RadGridStringId.FilterFunctionCustom:
                    return "自定义";
                case RadGridStringId.FilterFunctionDoesNotContain:
                    return "不包含";
                case RadGridStringId.FilterFunctionEndsWith:
                    return "以结尾";
                case RadGridStringId.FilterFunctionEqualTo:
                    return "等  于";
                case RadGridStringId.FilterFunctionGreaterThan:
                    return "大  于";
                case RadGridStringId.FilterFunctionGreaterThanOrEqualTo:
                    return "大于等于";
                case RadGridStringId.FilterFunctionLessThan:
                    return "小  于";
                case RadGridStringId.FilterFunctionLessThanOrEqualTo:
                    return "小于等于";
                case RadGridStringId.FilterFunctionNoFilter:
                    return "不过滤";
                case RadGridStringId.FilterFunctionStartsWith:
                    return "以开头";
                case RadGridStringId.FilterFunctionIsNull:
                    return "为  空";
                case RadGridStringId.FilterFunctionIsEmpty:
                    return "空  串";
                case RadGridStringId.FilterFunctionNotIsNull:
                    return "不为空";
                case RadGridStringId.FilterFunctionNotIsEmpty:
                    return "不为空串";
                case RadGridStringId.FilterFunctionNotEqualTo:
                    return "不等于";
                case RadGridStringId.FilterFunctionNotBetween:
                    return "不在之间";
                case RadGridStringId.FilterFunctionBetween:
                    return "在之间";
                case RadGridStringId.FilterOperatorBetween:
                    return "在之间";
                case RadGridStringId.FilterOperatorContains:
                    return "包  含";
                case RadGridStringId.FilterOperatorDoesNotContain:
                    return "不包含";
                case RadGridStringId.FilterOperatorEndsWith:
                    return "以结尾";
                case RadGridStringId.FilterOperatorEqualTo:
                    return "等  于";
                case RadGridStringId.FilterOperatorGreaterThan:
                    return "大  于";
                case RadGridStringId.FilterOperatorGreaterThanOrEqualTo:
                    return "大于等于";
                case RadGridStringId.FilterOperatorIsEmpty:
                    return "空  串";
                case RadGridStringId.FilterOperatorIsNull:
                    return "为  空";
                case RadGridStringId.FilterOperatorLessThan:
                    return "小  于";
                case RadGridStringId.FilterOperatorLessThanOrEqualTo:
                    return "小于等于";
                case RadGridStringId.FilterOperatorNoFilter:
                    return "不过滤";
                case RadGridStringId.FilterOperatorNotBetween:
                    return "不在之间";
                case RadGridStringId.FilterOperatorNotEqualTo:
                    return "不等于";
                case RadGridStringId.FilterOperatorNotIsEmpty:
                    return "不是空串";
                case RadGridStringId.FilterOperatorNotIsNull:
                    return "不为空";
                case RadGridStringId.FilterOperatorStartsWith:
                    return "以开头";
                case RadGridStringId.FilterOperatorIsLike:
                    return "包  含";
                case RadGridStringId.FilterOperatorNotIsLike:
                    return "不包含";
                case RadGridStringId.FilterOperatorIsContainedIn:
                    return "包含在内";
                case RadGridStringId.FilterOperatorNotIsContainedIn:
                    return "不包含在内";
                case RadGridStringId.FilterOperatorCustom:
                    return "自定义";
                case RadGridStringId.FilterCompositeNotOperator:
                    return "Not";
                case RadGridStringId.FilterFunctionDuringLast7days:
                    return "最后7天";
                case RadGridStringId.FilterFunctionSelectedDates:
                    return "选择日期";
                case RadGridStringId.FilterFunctionToday:
                    return "今天";
                case RadGridStringId.FilterFunctionYesterday:
                    return "昨天";
                case RadGridStringId.FilterLogicalOperatorAnd:
                    return "与";
                case RadGridStringId.FilterLogicalOperatorOr:
                    return "或";
                case RadGridStringId.FilterMenuAvailableFilters:
                    return "可用过滤器";
                case RadGridStringId.FilterMenuButtonCancel:
                    return "取消";
                case RadGridStringId.FilterMenuButtonOK:
                    return "确定";
                case RadGridStringId.FilterMenuClearFilters:
                    return "清除过滤器";
                case RadGridStringId.FilterMenuSearchBoxText:
                    return "搜索框";
                case RadGridStringId.FilterMenuSelectionAll:
                    return "选择全部";
                case RadGridStringId.FilterMenuSelectionAllSearched:
                    return "选择全部搜索";
                case RadGridStringId.FilterMenuSelectionNotNull:
                    return "不能为空";
                case RadGridStringId.FilterMenuSelectionNull:
                    return "空";
                case RadGridStringId.GroupingPanelDefaultMessage:
                    return "拖一列到面板进行分组";
                case RadGridStringId.GroupingPanelHeader:
                    return "分  组";
                case RadGridStringId.NoDataText:
                    return "没有数据";
                case RadGridStringId.PinMenuItem:
                    return "锁定状态";
                case RadGridStringId.PinAtLeftMenuItem:
                    return "左锁定";
                case RadGridStringId.PinAtRightMenuItem:
                    return "右锁定";
                case RadGridStringId.PasteMenuItem:
                    return "粘  贴";
                case RadGridStringId.SortAscendingMenuItem:
                    return "升  序";
                case RadGridStringId.SortDescendingMenuItem:
                    return "降  序";
                case RadGridStringId.UngroupThisColumn:
                    return "取消分组";
                case RadGridStringId.UnpinMenuItem:
                    return "解  锁";

                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
